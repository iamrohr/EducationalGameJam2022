using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    

    [SerializeField]private GameObject arrow;
    public float currentTime = 0f;
    private float startingTime = 20f;
    public bool isActivated; //The child of the gameobject (indicator)
    private bool timerActive;
    

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
            currentTime -= 1 * Time.deltaTime;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartTimer();

        if (timerActive == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Touched");

                
                
                    isActivated = true;
                    arrowIndicator.playersChildIndicator.SetActive(true);

            }
            while (timerActive == true)
            {
                this.enabled = false;
            }
            return;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
    
    private void StartTimer()
    {
        timerActive = true;
    }

   
    

}
