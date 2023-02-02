using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePlayer : MonoBehaviour
{
    public static DialoguePlayer Instance;
    [SerializeField] private TextMeshPro TextMeshPro;

    void Awake() => Instance = this;

    public void Talk(string Dialogue)
    {
        TextMeshPro.text = Dialogue;
        DialogueNPC.Instance.Timer = 5;
        DialogueNPC.Instance.TimerFunc();
    }
}
