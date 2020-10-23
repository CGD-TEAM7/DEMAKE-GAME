using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{ 
    public int healthValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
