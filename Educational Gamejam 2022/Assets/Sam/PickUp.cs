using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private bool fishTouched;

    //Add stuff when the player is touched here 

    



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (fishTouched == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fishTouched = true;
    }
}
