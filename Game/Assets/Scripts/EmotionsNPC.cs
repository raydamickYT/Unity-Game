using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionsNPC : MonoBehaviour
{
    public static EmotionsNPC Instance;
    Vector3 Tranform;
    [SerializeField] private GameObject Happy;
    [SerializeField] private GameObject Mad;
    [SerializeField] private GameObject Mid;


    void Awake() => Instance = this;

    private void Update() {
        Tranform = playerMovement.Instance.GetComponent<Rigidbody2D>().transform.position;
    }

    public void SadEmotion()
    {
        //als iemand nee zegt
        if (Jas.Instance.NoImpact > 0)
        {
            Instantiate(Happy, Tranform, Quaternion.identity);
        }
        else if (Jas.Instance.NoImpact < 0)
        {
            Instantiate(Mad, Tranform, Quaternion.identity);
        }
        else if (Jas.Instance.NoImpact == 0)
        {
            Instantiate(Mid, Tranform, Quaternion.identity);
        }

    }

    public void HappyEmotion()
    {
        print(ItemPickup.Instance.ColorNeutral);
        //als iemand ja zegt
        if (Jas.Instance.YesImpact > 0)
        {
            Instantiate(Happy, Tranform, Quaternion.identity);
        }
        else if (Jas.Instance.YesImpact < 0)
        {
            Instantiate(Mad, Tranform, Quaternion.identity);
        }
        else if (Jas.Instance.YesImpact == 0)
        {
            Instantiate(Mid, Tranform, Quaternion.identity);
        }
    }

    public void NeutralEmotion()
    {
        print(ItemPickup.Instance.ColorNeutral);
        //als iemand ja zegt
        if (Jas.Instance.NeutralImpact > 0)
        {
            Instantiate(Happy, transform.position, Quaternion.identity);
        }
        else if (Jas.Instance.NeutralImpact < 0)
        {
            Instantiate(Mad, transform.position, Quaternion.identity);
        }
        else if (Jas.Instance.NeutralImpact == 0)
        {
            Instantiate(Mid, transform.position, Quaternion.identity);
        }
    }
}
