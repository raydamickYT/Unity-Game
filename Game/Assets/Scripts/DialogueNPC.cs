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
    private bool Neutral = false; //check of player neutral was
    private bool TimerCheck = false; //check var voor Timer
    private bool TalkedTo, CanTalkTo = false;
    public float Timer = 2; //hoelang de timer duurt
    private string Dialogue;

    public TextMeshPro TextMeshPro;

    //text die de NPC de Player meegeeft
    [TextArea]
    public string DialogueNPCPlayerYes;
    [TextArea]
    public string DialogueNPCPlayerNo;
    [TextArea]
    public string DialogueNPCPlayerNeutral;

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
    [SerializeField] private string NeutraalNeutral;

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
    [SerializeField] private string TeDonkerNeutral;

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
    [SerializeField] private string TeLichtNeutral;

    void Awake() => Instance = this;

    private void Update()
    {
        JasColorCheck = Jas.Instance.ColorCounter;
        TimerFunc();
        StartText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CanTalkTo = true;
    }

    private void StartText()
    {
        if (!TalkedTo && CanTalkTo)
        {
            if (JasColorCheck > 0.2f && JasColorCheck < 0.8f) Neutraal();

            if (JasColorCheck < 0.2f) TeDonker();

            if (JasColorCheck > 0.8f) Telicht();
        }
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
        if (Input.GetKey(KeyCode.Alpha1) && ButtonPressed && !Yes)
        {
            CanTalkTo = false;
            Yes = true;
            if (Yes)
            {
                TalkedTo = true;
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = Neutraalyes;
                TimerCheck = true;
                //start thoughts after saying yes
                Dialogue = DialogueNPCPlayerYes;

            }
        }
        else if (Input.GetKey(KeyCode.Alpha2) && ButtonPressed && !No)
        {
            CanTalkTo = false;
            No = true;
            if (No)
            {
                TalkedTo = true;
                ItemPickup.Instance.Darker();
                TextMeshPro.text = NeutraalNo;
                TimerCheck = true;
                Dialogue = DialogueNPCPlayerNo;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3) && ButtonPressed && !No && !Yes)
        {
            CanTalkTo = false;
            Neutral = true;
            if (Neutral)
            {
                TalkedTo = true;
                ItemPickup.Instance.Neutral();
                TextMeshPro.text = NeutraalNeutral;
                TimerCheck = true;
                Dialogue = DialogueNPCPlayerNeutral;
                DialoguePlayer.Instance.Talk(Dialogue);
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
        if (Input.GetKey(KeyCode.Alpha1) && ButtonPressed && !Yes)
        {
            CanTalkTo = false;
            Yes = true;
            if (Yes)
            {
                TalkedTo = true;
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = TeDonkerYes;
                TimerCheck = true;
                //start thoughts after saying yes
                Dialogue = DialogueNPCPlayerYes;
                DialoguePlayer.Instance.Talk(Dialogue);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2) && ButtonPressed && !No)
        {
            CanTalkTo = false;
            No = true;
            if (No)
            {
                TalkedTo = true;
                ItemPickup.Instance.Darker();
                TextMeshPro.text = TeDonkerNo;
                TimerCheck = true;

                //start thoughts after saying yes
                Dialogue = DialogueNPCPlayerNo;
                DialoguePlayer.Instance.Talk(Dialogue);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3) && ButtonPressed && !No && !Yes)
        {
            CanTalkTo = false;
            Neutral = true;

            if (Neutral)
            {
                TalkedTo = true;
                ItemPickup.Instance.Neutral();
                TextMeshPro.text = NeutraalNeutral;
                TimerCheck = true;
                Dialogue = DialogueNPCPlayerNeutral;
                DialoguePlayer.Instance.Talk(Dialogue);
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
        if (Input.GetKey(KeyCode.Alpha1) && ButtonPressed && !Yes)
        {
            CanTalkTo = false;
            TalkedTo = true;
            Yes = true;
            if (Yes)
            {
                ItemPickup.Instance.Lighter();
                TextMeshPro.text = TeLichtYes;
                TimerCheck = true;

                //start thoughts after saying yes
                Dialogue = DialogueNPCPlayerYes;
                DialoguePlayer.Instance.Talk(Dialogue);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2) && ButtonPressed && !No)
        {
            CanTalkTo = false;
            No = true;
            if (No)
            {
                TalkedTo = true;
                ItemPickup.Instance.Darker();
                TextMeshPro.text = TeLichtNo;
                TimerCheck = true;

                //start thoughts after saying ...
                Dialogue = DialogueNPCPlayerNo;
                DialoguePlayer.Instance.Talk(Dialogue);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3) && ButtonPressed && !No && !Yes)
        {
            CanTalkTo = false;
            Neutral = true;
            if (Neutral)
            {
                TalkedTo = true;
                ItemPickup.Instance.Neutral();
                TextMeshPro.text = NeutraalNeutral;
                TimerCheck = true;
                Dialogue = DialogueNPCPlayerNeutral;
                DialoguePlayer.Instance.Talk(Dialogue);
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
        TextMeshPro.text = "";
        ButtonPressed = false;
        DialoguePlayer.Instance.Talk(Dialogue);
    }
}
