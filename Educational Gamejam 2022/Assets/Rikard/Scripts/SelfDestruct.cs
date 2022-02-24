using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructTime = 5f;
    private float randomDestructionTime;
    
    void Start()
    {
        randomDestructionTime = Random.Range(5f, selfDestructTime);
        
        StartCoroutine(SelfDestruction(randomDestructionTime));
    }
    
    IEnumerator SelfDestruction(float time)
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
        
    }
}
