using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jas : MonoBehaviour
{
    public static Jas Instance; //maak een var voor dit script
    public float ColorCounter = 0.5f;
    public float ColorStappen = 0.3f;

    //deze storen, de impact van de keuze zodat designers zelf kunnen kiezen per NPC of de keuze positief of negatief is.
    public float YesImpact;
    public float NoImpact;

    private void Start()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(ColorCounter, ColorCounter, ColorCounter);
    }

    void Awake() => Instance = this; //declare dat we dit script bedoelen

    private void Update()
    {
        if (ColorCounter <= 0.2f || ColorCounter >= 0.8f)
        {
            ColorStappen = 0.1f;
        }
        else if (ColorCounter > 0.2f || ColorCounter < 0.8f)
        {
            ColorStappen = 0.3f;
        }

        //VERWIJDER DIT LATER
        if (Input.GetKeyDown(KeyCode.K))
        {
            ColorCounter += ColorStappen;
            GetComponent<SpriteRenderer>().material.color = ItemPickup.Instance.Kleur;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ColorCounter -= ColorStappen;
            GetComponent<SpriteRenderer>().material.color = ItemPickup.Instance.Kleur;
        }


        //print(ColorCounter); //debug
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DialogueNPC>() != null)
        {
            var NPC = other.GetComponent<ItemPickup>();
            //hier wordt de waarde opgehaald en tijdelijk gestored.
            YesImpact = NPC.ColorYes;
            NoImpact = NPC.ColorNo;
        }
    }
}
