using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public float currentForce = 2f;

    public bool vertical = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(vertical)
        {
            collision.transform.Translate(new Vector2(0, -currentForce * Time.deltaTime), Space.World);
        }
        else
        {
            collision.transform.Translate(new Vector2(currentForce * Time.deltaTime, 0), Space.World);
        }
    }
}
