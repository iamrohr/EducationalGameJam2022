using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500;
    public float maxSpeed = 10;
    private float _maxSpeedReset;
    public float rotationSpeed = 350;
    public GameObject thrust1, thrust2;

    Rigidbody2D _rb2d;
    float rotation;
    
    
    //Dashes
    public float dashSpeed = 500f;
    public bool _canDash = true;
    public float _dashCoolDown = 1f;
    public float _dashCoolDownReset;
    
    

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _dashCoolDownReset = _dashCoolDown;
        _dashCoolDown = 0;
        _maxSpeedReset = maxSpeed;
    }

    void Update()
    {
        
        //Forward motion
        float acc = Input.GetAxis("Vertical");
        acc = Mathf.Clamp(acc, 0, 1);

        if (_rb2d.velocity.sqrMagnitude < maxSpeed * maxSpeed)
            _rb2d.AddForce(transform.up * acc * speed * Time.deltaTime);

        //Rotation
        float rot = Input.GetAxis("Horizontal");
        rotation -= rot * Time.deltaTime * rotationSpeed;
        _rb2d.MoveRotation(rotation);
        
        //Dash
        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            maxSpeed = dashSpeed;
            _canDash = false;
            if (_dashCoolDown <= 0)
            {
                Debug.Log("Dashing");
                _dashCoolDown = _dashCoolDownReset;
                _rb2d.AddForce(transform.up * dashSpeed, ForceMode2D.Impulse);
            }

            
        }
        //Dash Cooldown Counter Reset
        if (!_canDash)
        {
            _dashCoolDown -= Time.deltaTime;
            if (_dashCoolDown <= 0)
            {
                maxSpeed = _maxSpeedReset;
                _canDash = true;
                _dashCoolDown = _dashCoolDownReset;
            }
        }
        
        

        //Toggle art for the ship thrusters
        ToggleTrusters(acc, rot);
    }

    private void ToggleTrusters(float acc, float rot)
    {
        if (acc > 0)
        {
            thrust1.SetActive(true);
            thrust2.SetActive(true);
        }
        else if(rot < 0)
        {
            thrust1.SetActive(false);
            thrust2.SetActive(true);
        }
        else if (rot > 0)
        {
            thrust1.SetActive(true);
            thrust2.SetActive(false);
        }
        else
        {
            thrust1.SetActive(false);
            thrust2.SetActive(false);
        }
    }

    public void DashCoolDownCounter()
    {
        _dashCoolDown -= Time.deltaTime;
        if (_dashCoolDown <= 0)
        {
            _canDash = true;
            _dashCoolDown = _dashCoolDownReset;
        }
    }

}

