using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public bool hasOneMessage = true;
    public string messageOne;
    public string messageTwo;

    private bool enteredTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!enteredTrigger)
        {
            Collider2D player = Player.Instance.GetComponent<Collider2D>();

            if (collision == player)
            {
                if (hasOneMessage)
                {
                    StartCoroutine(UIManager.Instance.DialogRoutine(messageOne));
                }
                else
                {
                    StartCoroutine(UIManager.Instance.DialogRoutine(messageOne, messageTwo));
                }

                enteredTrigger = true;
            }
        }
    }
}
