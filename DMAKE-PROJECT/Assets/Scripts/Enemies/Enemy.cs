using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    protected Animator anim;
    protected SpriteRenderer sprite;

    public int Health { get; set; }
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int coins;
    [SerializeField] protected GameObject coinPrefab;

    [SerializeField] protected GameObject bloodEffect;

    protected bool inCombat = false;

    protected bool isDead = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if (!anim) Debug.LogError(name + " needs a Animator Component attached to a child object.");

        sprite = GetComponentInChildren<SpriteRenderer>();
        if (!sprite) Debug.LogError(name + " needs a Sprite Component attached to a child object.");

        Health = health;
    }

    public virtual void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (isDead)
            return;
    }

    public virtual void Death()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        anim.SetTrigger("dead");

        for(int i = 0; i < coins; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        isDead = true;
    }

    public virtual void Attack()
    {

    }

    public virtual void Movement()
    {

    }

    public void Damage(int damageAmount)
    {
        if (isDead)
            return;

        Instantiate(bloodEffect, transform.position, Quaternion.identity);

        Health -= damageAmount;
        StartCoroutine(Hurt());

        if (Health <= 0)
        {
            Death();
        }
    }

    IEnumerator Hurt()
    {
        Color red = new Color(0.5647059f, 0, 0);
        Color white = new Color(1f, 1f, 1f);

        sprite.color = red;

        yield return new WaitForSeconds(0.2f);

        sprite.color = white;
    }

}
