using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string Dialogue;
    public float ColorCounter = 1f;
    private bool ButtonPressed = false;
    private bool No = false; //check of player ja of nee heeft gezegd
    private bool Yes = false; //check om of player ja of nee heeft gezegd
    private bool TimerCheck = false; //check var voor Timer
    [SerializeField] private float Timer = 2; //hoeang de timer duurt

    public TextMesh Score;
    //private Color Kleur;
    public Color Kleur;

    private void Awake()
    {
    }

    private void Update()
    {
        Kleur = new Color(ColorCounter, ColorCounter, ColorCounter);
        TimerFunc();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!ButtonPressed) Score.text = Dialogue; //als F niet ingedrukt is dan laat hij de volgende tekst zien.

        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;
            Score.text = "Would you please help me? \n (Y) Yes          (N) No";
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed)
        {
            Yes = true;
            ColorCounter += 0.3f;
            var test = other.GetComponent<Jas>();
            test.JasSpeler.GetComponent<SpriteRenderer>().material.color = Kleur;
            //Destroy(gameObject);
            if (Yes)
            {
                Score.text = "Thank You SO much";
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed)
        {
            No = true;
            ColorCounter -= 0.3f;
            var test = other.GetComponent<Jas>();
            test.JasSpeler.GetComponent<SpriteRenderer>().material.color = Kleur;
            if (No)
            {
                Score.text = "Dickhead";
                TimerCheck = true;
            }
        }


    }
    public void TimerFunc()
    {
        if (TimerCheck)
        {
            Timer -= Time.deltaTime;
            print(Timer);
            if (Timer <= 0)
            {
                Score.text = "";
                TimerCheck = false;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(!ButtonPressed) TimerCheck = true;
        if (ButtonPressed && !No && !Yes)
        {
            TimerCheck = true;
            Score.text = "HEY, GET BACK HERE";
            ColorCounter -= 0.3f;
            var test = other.GetComponent<Jas>();
            test.JasSpeler.GetComponent<SpriteRenderer>().material.color = Kleur;
        }
    }
}
