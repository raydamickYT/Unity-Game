using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float ColorCounter = 1f;
    private bool Pressed = false;
    private bool No = false;
    private bool Yes = true;
    public TextMesh Score;
    //private Color Kleur;
    public Color Kleur;
    [SerializeField] public GameObject Player;


    private void Awake()
    {
    }

    private void Update()
    {
        Kleur = new Color(ColorCounter, ColorCounter, ColorCounter);

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!Pressed) Score.text = "Press F \n start mission?"; //als F niet ingedrukt is dan laat hij de volgende tekst zien.

        if (Input.GetKey(KeyCode.F))
        {
            Pressed = true;
            Score.text = "Would you please help me? \n (Y) Yes          (N) No";
        }
        if (Input.GetKey(KeyCode.Y) && Pressed)
        {
            ColorCounter += 0.3f;
            var test = other.GetComponent<playerMovement>();
            test.Player.GetComponent<SpriteRenderer>().material.color = Kleur;
            //Destroy(gameObject);
            if (Yes)
            {
                Score.text = "Thank You SO much";
            }
        }
        if (Input.GetKey(KeyCode.N) && Pressed)
        {
            No = true;
            ColorCounter -= 0.3f;
            var test = other.GetComponent<playerMovement>();
            Player.GetComponent<SpriteRenderer>().material.color = Kleur;
            if (No)
            {
                Score.text = "Dickhead";
            }
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        float Timer = 4;
        if (Pressed && !No && !Yes)
        {
            Score.text = "HEY, GET BACK HERE";
            ColorCounter -= 0.3f;
            Timer -= Time.deltaTime;
            if (Timer == 0)
            {
                Score.text = "";
            }
        }

    }
}
