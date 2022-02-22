using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float dashSpeed;
    private float _dashTime;
    public float startDashTime;
    private int _direction;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dashTime = startDashTime;
    }
    
    void Update()
    {
 
    }
}
