using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private GameObject interaction;
    [SerializeField] private float hideObjectAtRange;  //Hides the indicator at a certain range can be set

    //----------------------------------------------------------------------------------------------------------------

    public GameObject playersChildIndicator;
    private float angle; //Angle of the object.

    //----------------------------------------------------------------------------------------------------------------

    Interact interact;

    public void Start()
    {
        interact = interaction.GetComponent<Interact>();  //Gets interact component.
        playersChildIndicator.SetActive(false);
    }

    private void Update()
    {
        //Scripts below make the indicator lock on.
        Vector3 direction = interact.star.position - transform.position;


        if (direction.magnitude < hideObjectAtRange)
        {
            IndicatorActive(false);
        }
        else
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    
    }
   
    private void IndicatorActive(bool Activity)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(Activity);
        }
    }
    
}
