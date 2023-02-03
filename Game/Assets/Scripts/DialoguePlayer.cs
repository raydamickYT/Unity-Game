using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePlayer : MonoBehaviour
{
    bool TimerStart = false;
    float TimerTime;


    public static DialoguePlayer Instance;
    [SerializeField] private TextMeshPro TextMeshPro;

    void Awake() => Instance = this;

    private void Update()
    {
        Timer();
    }

    public void Talk(string Dialogue)
    {
        TextMeshPro.text = Dialogue;
        TimerStart = true;
        TimerTime = 3f;
    }

    private void Timer()
    {
        if (TimerStart)
        {
            TimerTime -= Time.deltaTime;
            if (TimerTime <= 0)
            {
                TextMeshPro.text = "";
                TimerStart = false;
            }
        }
    }
}
