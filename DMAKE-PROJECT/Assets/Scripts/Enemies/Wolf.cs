using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    private float attackDistance = 0.8f;

    private float distToFollow = 7f;
    private bool moveToPlayer = false;
    private bool inCombat = false;

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
                Patrol();
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

    public void Patrol()
    {

    }

    public void InCombat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position * 1.3f, speed * Time.deltaTime);
        anim.SetBool("Running", true);

        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < attackDistance)
        {
            anim.SetTrigger("Attack");
        }

        if (Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow) inCombat = false;

    }




}
