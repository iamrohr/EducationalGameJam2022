using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetStarInPlace : MonoBehaviour
{
    [SerializeField] private GameObject selectedStar;           //The star that needs to touch the object.
    [SerializeField] GameObject Particles;                      //The particle object.

    private void Start()
    {
        Particles.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fishy"))
        {
            selectedStar.SetActive(false);
            Particles.SetActive(true);
        }
    }

}
