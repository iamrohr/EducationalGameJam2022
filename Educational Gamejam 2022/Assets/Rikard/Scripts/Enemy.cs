using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementDuration = 2.0f;
    private float waitBeforeMoving = 2.0f;
    private bool hasArrived = false;

    private Vector3 currentPosition;

    private void start()
    {
        movementDuration = Random.Range(5.0f, 10.0f);
        waitBeforeMoving = Random.Range(0.5f, 3.0f);
        
    }
    
    private void Update()
    {
        currentPosition = transform.position;
        
        if(!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(-3f, 3f);
            float randY = Random.Range(-3f, 3f);
            StartCoroutine(MoveToPoint(new Vector3(currentPosition.x + randX, currentPosition.y + randY, 0)));
        }
    }
 
    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;
 
        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(currentPosition, targetPos, t);
 
            yield return null;
        }
 
        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }
}
