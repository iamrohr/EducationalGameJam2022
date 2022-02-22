using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    

    [SerializeField]private GameObject arrow; //To call stuff from Arrowindicator script.
    public float currentTime = 0f;
    private float startingTime = 20f;
    public bool isActivated; //The child of the gameobject (indicator)
    public bool timerActive; //Checks if the timer is active
    
    //Don't forget to set the bools private again.
    ArrowIndicator arrowIndicator;

    private void Start()
    {
        arrowIndicator = arrow.GetComponent<ArrowIndicator>();
        isActivated = false; //Star Hint is set to false.
        currentTime = startingTime;
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime -= Time.deltaTime;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        StartTimer();
        Debug.Log("Touched");
        if (timerActive == true)
        {
            if (other.gameObject.tag == "Player")
            {
                isActivated = true;
                arrowIndicator.playersChildIndicator.SetActive(true);
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
        if (timerActive == false)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }

    private void StartTimer()
    {
        if (currentTime <= 20)
        {
            timerActive = true;
        }
        else if (currentTime >= 0)
        {
            timerActive = false;
            currentTime = 20f;
        }
    }

   
    

}
