using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public static ItemPickup Instance;
    [SerializeField] public float ChoiceYes;
    [SerializeField] public float ChoiceNo;

    [TextArea]
    [SerializeField] private string Dialogue1;
    [TextArea]
    [SerializeField] private string Dialogue2;
    [TextArea]
    [SerializeField] private string DialogueYes;
    [TextArea]
    [SerializeField] private string DialogueNo;
    [TextArea]
    [SerializeField] private string DialogueWalkAway;

    public float TempColorCounter;
    private bool ButtonPressed = false;
    private bool No = false; //check of player ja of nee heeft gezegd
    private bool Yes = false; //check om of player ja of nee heeft gezegd
    private bool TimerCheck = false; //check var voor Timer
    [SerializeField] private float Timer = 2; //hoelang de timer duurt

    public TextMeshPro Score;
    //private Color Kleur;
    public Color Kleur;

    void Awake() => Instance = this;

    private void FixedUpdate()
    {
        TempColorCounter = Mathf.Abs(Jas.Instance.ColorCounter);
        //print(TempColorCounter);
    }

    private void Update()
    {
        Kleur = new Color(TempColorCounter, TempColorCounter, TempColorCounter);
        TimerFunc();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!ButtonPressed) Score.text = Dialogue1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            Score.text = Dialogue2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
             print("2");
            Yes = true;
            TempColorCounter += Jas.Instance.ColorStappen * ChoiceYes;
            Jas.Instance.ColorCounter = TempColorCounter;
            Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
            if (Yes)
            {
                Score.text = DialogueYes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            print("1");
            No = true;
            TempColorCounter += Jas.Instance.ColorStappen * ChoiceNo;
            Jas.Instance.ColorCounter = TempColorCounter;
            Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
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
            //print(Timer);

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Score.text = "";
                TimerCheck = false;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!ButtonPressed) TimerCheck = true;
        if (ButtonPressed && !No && !Yes)
        {
            TimerCheck = true;
            Score.text = "HEY, GET BACK HERE";
            TempColorCounter += (Jas.Instance.ColorStappen / 2) * ChoiceNo;
            Jas.Instance.ColorCounter = TempColorCounter;
            Jas.Instance.GetComponent<SpriteRenderer>().material.color = Kleur;
        }
    }
}
