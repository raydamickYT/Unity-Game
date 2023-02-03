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
    public float ColorNeutral;

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
        //wordt gezegd als iemand nee zegt (2)
        EmotionsNPC.Instance.SadEmotion();
        //de stored values worden hier gebruikt om de kleur positief of negatief te beïnvloeden.
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * Jas.Instance.NoImpact;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }

    public void Lighter()
    {
        //wordt gecalld als iemand ja zegt (1)
        EmotionsNPC.Instance.HappyEmotion();
        Jas.Instance.ColorCounter += Jas.Instance.ColorStappen * Jas.Instance.YesImpact;
        Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
    }

    public void Neutral()
    {
        //wordt gecalld als iemand 3 kiest
        //do nothing if it's in the safe space of 0.21 - 0.79
        if (Jas.Instance.ColorCounter > 0.2f && Jas.Instance.ColorCounter < 0.8)
        {
            EmotionsNPC.Instance.NeutralEmotion();
        }
        if (Jas.Instance.ColorCounter <= 0.2f)
        {
            EmotionsNPC.Instance.NeutralEmotion();
            //change color in a positive way
            Jas.Instance.ColorCounter -= 0.1f;
            Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
        }
        else if (Jas.Instance.ColorCounter >= 0.8f)
        {
            EmotionsNPC.Instance.NeutralEmotion();
            //change color in a positive way
            Jas.Instance.ColorCounter += 0.1f;
            Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
        }
    }
}
