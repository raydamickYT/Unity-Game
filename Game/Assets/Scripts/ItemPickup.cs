using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public static ItemPickup Instance;

    //deze worden gelezen wanneer de player collide met de NPC
    public float ColorYes;
    public float ColorNo;

    public Color Kleur;

    //maak het script toegankelijk voor andere scripts
    void Awake() => Instance = this;

    private void Update()
    {
        //jas is de kleur van de ColorCounter
        //print(ColorYes);
        Kleur = new Color(Jas.Instance.ColorCounter, Jas.Instance.ColorCounter, Jas.Instance.ColorCounter);
    }

    public void Darker()
    {
        //de stored values worden hier gebruikt om de kleur positief of negatief te beïnvloeden.
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * Jas.Instance.NoImpact;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }

    public void Lighter()
    {
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * Jas.Instance.YesImpact;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }
}
