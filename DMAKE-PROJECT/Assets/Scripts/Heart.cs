using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private AudioSource audioSource;
    public int healthValue = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.AddHealth(healthValue);
            audioSource.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
