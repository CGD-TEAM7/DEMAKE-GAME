using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : MonoBehaviour
{
    public float speed = 15f;

    private void Start()
    {
        StartCoroutine(FlyRoutine());
    }

    private IEnumerator FlyRoutine()
    {
        Vector2 targetPos = Player.Instance.transform.position;

        Vector3 moveDirection = targetPos - (Vector2)transform.position;

        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 45, Vector3.forward);
        }

        while (Vector2.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);
    }
}
