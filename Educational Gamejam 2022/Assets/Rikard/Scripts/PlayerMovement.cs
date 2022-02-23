using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500;
    public float maxSpeed = 5;
    private float _maxSpeedReset;
    public float rotationSpeed = 350;
    public GameObject thrust1, thrust2;

    Rigidbody2D _rb2D;
    float rotation;
    
    
    //Dashes
    public bool _isDashing;
    public bool _canDash = true;
    private float _dashSpeed = 10f;
    private float _speedAfterDash = 2.5f;
    public float _dashCoolDown = 1f;
    public float _dashCoolDownReset;


    public float dashDistance = 15f;
    public float timeDashing = 0.4f;
    public Transform dashTowards;    
    
    

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _dashCoolDownReset = _dashCoolDown;
        _dashCoolDown = 0;
        _maxSpeedReset = maxSpeed;
    }

    void Update()
    {
        
        //Forward motion
        if (_canDash)
        {
            float acc = Input.GetAxis("Vertical");
            acc = Mathf.Clamp(acc, 0, 1);

            if (_rb2D.velocity.sqrMagnitude < maxSpeed * maxSpeed)
                _rb2D.AddForce(transform.up * acc * speed * Time.deltaTime);
        }


        //Dash
        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            //Get the dash direction
            Vector2 direction = (transform.position - dashTowards.position).normalized;
            //Get the current position of the player
            Vector2 currentPosition = _rb2D.position;
            _canDash = false;
            Debug.Log("Dashing towards" + direction);
            _dashCoolDown = _dashCoolDownReset;
            StartCoroutine(Dash(direction, currentPosition));
        }
        
        //Dash Cooldown Counter Reset
        if (!_canDash)
        {
            _dashCoolDown -= Time.deltaTime;
            if (_dashCoolDown <= 0)
            {
                _canDash = true;
                _dashCoolDown = _dashCoolDownReset;
            }
        }
        
        //Rotation
        float rot = Input.GetAxis("Horizontal");
        rotation -= rot * Time.deltaTime * rotationSpeed;
        _rb2D.MoveRotation(rotation);

        //Toggle art for the ship thrusters
        // ToggleTrusters(acc, rot);
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

    IEnumerator Dash(Vector2 direction, Vector3 oldPosition)
    {
        _isDashing = true;
        direction = direction * -1;
        _rb2D.AddForce(direction * _dashSpeed, ForceMode2D.Impulse);
        Debug.Log("Dashing Coroutine Started");
        yield return new WaitForSeconds(timeDashing); //Time Dashing
        //Set Velocity to 0
        _rb2D.velocity = Vector2.zero;
        
        //Get the dash direction and apply force after dash is done
        Vector2 directionAfterDash = (transform.position - oldPosition).normalized;
        _rb2D.AddForce(directionAfterDash * _speedAfterDash, ForceMode2D.Impulse);
        _isDashing = false;
    }

}

