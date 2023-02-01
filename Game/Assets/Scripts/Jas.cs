using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jas : MonoBehaviour
{
    public static Jas Instance; //maak een var voor dit script
    public float ColorCounter = 0.5f;
    public float ColorStappen = 0.3f;

    void Awake() => Instance = this; //declare dat we dit script bedoelen

    private void Update() {
        // if(ColorCounter <= 0.2f || ColorCounter >= 0.8f){
        //     ColorStappen -= 0.2f;
        // } else if(ColorCounter > 0.2f || ColorCounter < 0.8f){
        //     ColorStappen += 0.2f;
        // }
        print(ColorCounter);
    }
}
