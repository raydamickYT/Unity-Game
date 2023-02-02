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
    [SerializeField] private string Neutraal1;
    [TextArea]
    [SerializeField] private string Neutraal2;
    [TextArea]
    [SerializeField] private string Neutraalyes;
    [TextArea]
    [SerializeField] private string NeutraalNo;
    [TextArea]
    [SerializeField] private string NeutraalWalkAway;

    //text voor te licht
    [TextArea]
    [SerializeField] private string TeDonker1;
    [TextArea]
    [SerializeField] private string TeDonker2;
    [TextArea]
    [SerializeField] private string TeDonkerYes;
    [TextArea]
    [SerializeField] private string TeDonkerNo;
    [TextArea]
    [SerializeField] private string TeDonkerWalkAway;

    //text voor te donker
    [TextArea]
    [SerializeField] private string TeLicht1;
    [TextArea]
    [SerializeField] private string TeLicht2;
    [TextArea]
    [SerializeField] private string TeLichtYes;
    [TextArea]
    [SerializeField] private string TeLichtNo;
    [TextArea]
    [SerializeField] private string TeLichtWalkAway;

    void Awake() => Instance = this;

    private void Update()
    {
        JasColorCheck = Jas.Instance.ColorCounter;
        TimerFunc();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (JasColorCheck > 0.2f && JasColorCheck < 0.8f) Neutraal();

        if (JasColorCheck < 0.2f) TeDonker();

        if (JasColorCheck > 0.8f) Telicht();
    }

    private void Neutraal()
    {
        //print("N"); //debug

        if (!ButtonPressed) TextMeshPro.text = Neutraal1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            TextMeshPro.text = Neutraal2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = Neutraalyes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            No = true;
            if (No)
            {
                ItemPickup.Instance.Darker();
                TextMeshPro.text = NeutraalNo;
                TimerCheck = true;
            }
        }
    }

    private void TeDonker()
    {
        //print("te donker"); //debug
        if (!ButtonPressed) TextMeshPro.text = TeDonker1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            TextMeshPro.text = TeDonker2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = TeDonkerYes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            No = true;
            if (No)
            {
                ItemPickup.Instance.Darker();
                TextMeshPro.text = TeDonkerNo;
                TimerCheck = true;
            }
        }

    }

    private void Telicht()
    {
        //print("Licht"); //debug
        if (!ButtonPressed) TextMeshPro.text = TeLicht1; //als F niet ingedrukt is dan laat hij de volgende tekst zien.
        if (Input.GetKey(KeyCode.F))
        {
            ButtonPressed = true;//om te checken of we niet aan het speedrunnen zijn
            TextMeshPro.text = TeLicht2;
        }
        if (Input.GetKey(KeyCode.Y) && ButtonPressed && !Yes)
        {
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = TeLichtYes;
                TimerCheck = true;
            }
        }
        if (Input.GetKey(KeyCode.N) && ButtonPressed && !No)
        {
            No = true;
            if (No)
            {
                ItemPickup.Instance.Darker();
                TextMeshPro.text = TeLichtNo;
                TimerCheck = true;
            }
        }
    }

    private void WalkAway()
    {
        if (JasColorCheck > 0.2f && JasColorCheck < 0.8f)
        {
            print("test");
            ItemPickup.Instance.WalkingAwayLighter();
            TextMeshPro.text = NeutraalWalkAway;
        }
        if (JasColorCheck <= 0.2f)
        {
            print("test");
            ItemPickup.Instance.Darker();
            TextMeshPro.text = TeDonkerWalkAway;
        }
        ItemPickup.Instance.Lighter();
        print("test");
        if (JasColorCheck >= 0.8f)
        {
            TextMeshPro.text = TeLichtWalkAway;
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
        if(!ButtonPressed) TextMeshPro.text = "";
        else if(ButtonPressed) WalkAway();
    }
}
