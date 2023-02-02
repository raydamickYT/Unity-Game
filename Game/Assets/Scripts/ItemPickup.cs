using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public static ItemPickup Instance;
    [SerializeField] private float ColorYes = 1;
    [SerializeField] private float ColorNo;

    public Color Kleur;

    //maak het script toegankelijk voor andere scripts
    void Awake() => Instance = this;

    private void Update()
    {
        //jas is de kleur van de ColorCounter
        //print(ColorNo);
        Kleur = new Color(Jas.Instance.ColorCounter, Jas.Instance.ColorCounter, Jas.Instance.ColorCounter);
    }

    public void Darker()
    {
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * ColorNo;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }

    public void Lighter()
    {
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * ColorYes;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }
}
