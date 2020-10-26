using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour
{
    public GameObject hedge, hedge1, hedge2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = Player.Instance.gameObject.GetComponent<Collider2D>();
        if (collision == collider)
        {
            hedge.SetActive(true);
            hedge1.SetActive(true);
            hedge2.SetActive(true);
        }
    }
}
