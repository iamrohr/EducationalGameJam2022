using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float speed;       //The speed value of the smaller fish
    [SerializeField] private Transform player;  //Object it has to follow
    public bool fishTouched;                   //Checks if the fish is touched


    public GameObject enemyToActivate;
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
            enemyToActivate.SetActive(true);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        fishTouched = true;
    }
}
