using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevel : MonoBehaviour
{
    public GameObject LevelToActivate;

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelToActivate.SetActive(true);
        }
    }
}
