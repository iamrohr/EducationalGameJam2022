using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    

    [SerializeField]private GameObject arrow; //To call stuff from Arrowindicator script.
    public float currentTime = 0f;
    private float startingTime = 20f; //The starting time.
    public bool isActivated; //The child of the gameobject (indicator)
    public bool timerActive; //Checks if the timer is active
    
    //Don't forget to set the bools private again.
    ArrowIndicator arrowIndicator;

    private void Start()
    {
        arrowIndicator = arrow.GetComponent<ArrowIndicator>(); //Gets the ArrowIndicator component.
        isActivated = false; //Star Hint is set to false.
        currentTime = startingTime; //sets current time to starting time
    }

    private void Update()
    {
        if (timerActive == true)    //timer stuff
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = startingTime;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;   //Sets the collider on enabled
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartTimer();
        if (timerActive == true)
        {
            if (other.gameObject.tag == "Player")
            {
                isActivated = true;
                arrowIndicator.playersChildIndicator.SetActive(true); 
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false; //disables the collider
            }
        }

    }

    private void StartTimer()
    {
        if (currentTime <= 20)
        {
            timerActive = true;
        }
    }

   
    

}
