using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draugr : Enemy
{
    public Transform playerPosition;

    private float distToStopFollow = 3f;
    private bool moveToPlayer = false;

    void Awake()
    {
        speed = 0.02f;
    }

    void Update()
    {
        if(!isDead)
        {
            if (Vector2.Distance(transform.position, playerPosition.position) < distToStopFollow)
            {   
                Movement();
            }
        }

        
    }

    public override void Movement()
    {
        StartCoroutine(coMovement());
    }

    IEnumerator coMovement()
    { 
        moveToPlayer = true;
        Vector2 targetPos = Player.Instance.transform.position;

        while (moveToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos) < 0.1f) moveToPlayer = false;
            yield return null;
        }
    }
}
