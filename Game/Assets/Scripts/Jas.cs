using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jas : MonoBehaviour
{
    private float ColorCounter;

    [SerializeField] public GameObject JasSpeler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var NPC = other.GetComponent<ItemPickup>();
        //ColorCounter = NPC.ColorCounter;
    }
}
