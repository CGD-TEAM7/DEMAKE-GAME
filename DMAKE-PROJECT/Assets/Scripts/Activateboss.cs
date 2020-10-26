using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateboss : MonoBehaviour
{
    public GameObject hedge, hedge1, hedge2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Player.Instance.gameObject)
        {
            hedge.SetActive(true);
            hedge1.SetActive(true);
            hedge2.SetActive(true);
        }
    }
   
}
