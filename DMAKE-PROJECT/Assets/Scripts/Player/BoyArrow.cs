using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyArrow : MonoBehaviour
{
    public GameObject boss;
    public float speed = 15f;

    private void Start()
    {
        StartCoroutine(FlyRoutine());
    }

    private IEnumerator FlyRoutine()
    {
        Vector2 targetPos = boss.transform.position;

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

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
    
}
