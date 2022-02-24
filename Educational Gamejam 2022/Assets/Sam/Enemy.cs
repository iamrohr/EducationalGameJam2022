using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReturnHome : MonoBehaviour
{


    [SerializeField] Vector3 originalLocation;
    [SerializeField] Vector3 currentLocation;

    public PickUp pickup;

    void Start()
    {
        originalLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jellyfish")
        {
            gameObject.transform.position = originalLocation;
            pickup.fishTouched = false;
        }
    }
     
}
