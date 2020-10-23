using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointValue = 1;
    public GameObject collectEffect;

    private void Start()
    {
        StartCoroutine(MoveToTarget(CalculateTarget(), 0.15f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.AddPoints(pointValue);
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private Vector2 CalculateTarget()
    {
        float randX = Random.Range(transform.position.x + 1, transform.position.x - 1);
        float randY = Random.Range(transform.position.y + 1, transform.position.y - 1);

        return new Vector2(randX, randY);
    }

    private IEnumerator MoveToTarget(Vector2 target, float lerpValue)
    {
        while(Vector2.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, target, lerpValue);
            yield return null;
        }
    }
}
