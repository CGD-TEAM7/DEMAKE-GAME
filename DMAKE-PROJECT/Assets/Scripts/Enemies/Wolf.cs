using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    private float attackDistance = 0.8f;

    private float distToFollow = 10f;
    private bool moveToPlayer = false;

    public override void Init()
    {
        base.Init();
        StartCoroutine(Move());
    }


    public IEnumerator Move()
    {
        while (!isDead)
        {
            while (Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow && !isDead)
            {
                yield return null;
            }

            inCombat = true;
            while (inCombat && !isDead)
            {
                InCombat();
                yield return null;
            }

            anim.SetBool("Running", false);
            yield return null;
        }

    }

    public void InCombat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.deltaTime);
        anim.SetBool("Running", true);

        if(transform.position.x < Player.Instance.transform.position.x)
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

        if (Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow) inCombat = false;

    }
}
