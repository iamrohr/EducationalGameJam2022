using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetStarInPlace : MonoBehaviour
{
    [SerializeField] private GameObject selectedStar;
    [SerializeField] GameObject Particles;

    public GameObject enemyToActivate;

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
            Destroy(enemyToActivate);
        }
    }

}
