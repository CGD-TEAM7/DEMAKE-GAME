using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public float currentForce = 2f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.transform.Translate(new Vector2(currentForce * Time.deltaTime, 0), Space.World);
    }
}
