using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateboss : MonoBehaviour
{
    public Animator gateAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = Player.Instance.gameObject.GetComponent<Collider2D>();
        if (collision == collider)
        {
            gateAnim.SetTrigger("close");

            Boss boss = FindObjectOfType<Boss>();
            boss.bossFightStarted = true;

            Boy boy = FindObjectOfType<Boy>();
            boy.canFireArrows = true;
        }
    }

    
}
