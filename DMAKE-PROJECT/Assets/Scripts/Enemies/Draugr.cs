using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draugr : Enemy
{
    private float attackDistance = 0.8f;

    private float distToFollow = 3f;
    private bool moveToPlayer = false;

    public Transform target;
    private Vector2 originalPos;

    private bool destReached = false;

    public override void Init()
    {
        base.Init();
        StartCoroutine(Move());
    }


    public IEnumerator Move()
    {
        originalPos = transform.position;

         while (!isDead) 
         {
             while(Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow && !isDead)
             {
                Patrol();
                 yield return null;
             }

             inCombat = true;
             while(inCombat && !isDead)
             {
                 InCombat();
                 yield return null;
             }

             anim.SetBool("Running", false);
             yield return null;
         }
        
    }

    public void Patrol()
    {
        anim.SetBool("Running", true);

        if(!destReached)
        {
            if (Vector2.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime * 0.8f);
            }
            else
            {
                destReached = true;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, originalPos) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPos, speed * Time.deltaTime * 0.8f);
            }
            else
            {
                destReached = false;
            }
        }
    }

    public void InCombat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.deltaTime);
        anim.SetBool("Running", true);

        if (transform.position.x < Player.Instance.transform.position.x)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < attackDistance)
        {
            anim.SetTrigger("Attack");
        }

        //if (Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow) inCombat = false;
        
    }

}
