using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject rock;
    public Transform rockSpawnPos;

    [HideInInspector] public bool bossFightStarted = false;
    [HideInInspector] public bool bossIsDead = false;


    public override void Init()
    {
        base.Init();
        StartCoroutine(BossBehaviour());
    }

    IEnumerator BossBehaviour()
    {
        while(!bossFightStarted)
        {
            yield return null;
        }

        while(!isDead)
        {
            float randomXPoint = Random.Range(-7f, 7.5f);
            float randomYPoint = Random.Range(88f, 96f);
            Vector2 targetPos = new Vector2(randomXPoint, randomYPoint);

            while (Vector2.Distance(transform.position, targetPos) > 0.1f && !isDead)
            {
                anim.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                if (transform.position.x < Player.Instance.transform.position.x)
                {
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2(1, transform.localScale.y);
                }

                yield return null;
            }

            anim.SetBool("isRunning", false);
            yield return new WaitForSeconds(2f);

            int randNum = Random.Range(0, 10);

            if(!isDead)
            {
                if (randNum < 5)
                {
                    StartCoroutine(ChargeAtPlayer());
                }
                else
                {
                    ThrowRock();
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void ThrowRock()
    {
        anim.SetTrigger("throwRock");
        Instantiate(rock, rockSpawnPos.position, Quaternion.identity);
    }

    private IEnumerator ChargeAtPlayer()
    {
        anim.SetBool("isCharging", true);

        Vector2 playerPos = Player.Instance.transform.position;

        while(Vector2.Distance(transform.position, playerPos) > 0.1f && !isDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime * 2);
            yield return null;
        }

        anim.SetBool("isCharging", false);
    }

    public override void Death()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        anim.SetTrigger("dead");

        int finishTime = Mathf.RoundToInt(GameManager.Instance.time);

        //2 mins = - 12
        //3 mins = - 18
        //4 mins = - 24
        //5 mins = - 30

        coins = 35 - Mathf.RoundToInt(finishTime / 10);

        if(coins > 0)
        {
            for (int i = 0; i < coins; i++)
            {
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }
        }

        StartCoroutine(GameManager.Instance.LoadLevelRoutine("WinMenu", 8f));

        bossIsDead = true;
        isDead = true;
    }
}

