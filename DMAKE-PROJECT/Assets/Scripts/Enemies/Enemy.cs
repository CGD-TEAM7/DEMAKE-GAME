using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Animator anim;

    public int Health { get; set; }
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int coins;
    [SerializeField] protected GameObject coinPrefab;

    protected bool isDead = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        if(!anim) Debug.LogError(name + " needs a Animator Component attached to a child object.");

        Health = health;
    }

    public virtual void Update()
    {
        if (isDead)
            return;
    }

    public virtual void Death()
    {
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

        Health -= damageAmount;

        if (Health <= 0)
        {
            Death();
        }
    }
}
