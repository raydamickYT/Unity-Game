using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueNPC : MonoBehaviour
{
    public static DialogueNPC Instance;
    private bool ButtonPressed = false;
    private float JasColorCheck;
    private bool No = false; //check of player ja of nee heeft gezegd
    private bool Yes = false; //check om of player ja of nee heeft gezegd
    private bool TimerCheck = false; //check var voor Timer
    [SerializeField] private float Timer = 2; //hoelang de timer duurt

    public TextMeshPro TextMeshPro;
    //text voor het aardige deel
    [TextArea]
    [SerializeField] private string Aardig1;
    [TextArea]
    [SerializeField] private string Aardig2;
    [TextArea]
    [SerializeField] private string AardigYes;
    [TextArea]
    [SerializeField] private string AardigNo;
    [TextArea]
    [SerializeField] private string AardigWalkAway;

    //text voor deel niet aardig
    [TextArea]
    [SerializeField] private string NietAardig1;
    [TextArea]
    [SerializeField] private string NietAardig2;
    [TextArea]
    [SerializeField] private string NietAardigYes;
    [TextArea]
    [SerializeField] private string NietAardigNo;
    [TextArea]
    [SerializeField] private string NietAardigWalkAway;

    private void Start() {
        
    }

    void Awake() => Instance = this;

    private void Update()
    {
        JasColorCheck = Jas.Instance.ColorCounter;
        TimerFunc();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (JasColorCheck > 0.2f && JasColorCheck < 0.8f)
        {
            Aardig();
        }

        if (JasColorCheck < 0.2)
        {
            NietAardig();
        }

    }

    private void Aardig()
    {
        if (!ButtonPressed) TextMeshPro.text = Aardig1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            TextMeshPro.text = Aardig2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = AardigYes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            No = true;
            if (No)
            {
                ItemPickup.Instance.Darker();
                TextMeshPro.text = AardigNo;
                TimerCheck = true;
            }
        }
    }

    private void NietAardig()
    {
        if (!ButtonPressed) TextMeshPro.text = NietAardig1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            TextMeshPro.text = NietAardig2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();   
                TextMeshPro.text = NietAardigYes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            No = true;
            if (No)
            {
                ItemPickup.Instance.Darker();
                TextMeshPro.text = NietAardigNo;
                TimerCheck = true;
            }
        }
    }
    public void TimerFunc()
    {
        if (TimerCheck)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                TextMeshPro.text = "";
                TimerCheck = false;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!ButtonPressed) TimerCheck = true;
        if (ButtonPressed && !No && !Yes)
        {
            ItemPickup.Instance.Darker();
            TimerCheck = true;
            TextMeshPro.text = AardigWalkAway;
        }
    }
}
