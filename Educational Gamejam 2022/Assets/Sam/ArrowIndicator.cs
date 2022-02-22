using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private Transform star; //Drag the star that you need to take into the inspector.
    [SerializeField] private float hideObjectAtRange;  //Hides the indicator at a certain range can be set
   

    public GameObject playersChildIndicator;

    private float angle; //Angle of the object.

    public void Start()
    {
        playersChildIndicator.SetActive(false);
    }

    private void Update()
    {
        //Scripts below make the indicator lock on.
        Vector3 direction = star.position - transform.position;


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
