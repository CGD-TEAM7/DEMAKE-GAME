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
        StartCoroutine(Hurt());

        if (Health <= 0)
        {
            Death();
        }
    }

    IEnumerator Hurt()
    {
        Color OriginalColour = sprite.color;
        sprite.color = new Color(0.6117f,0.1254f, 0.1254f);

        yield return new WaitForSeconds(0.2f);

        sprite.color = OriginalColour;
    }

}
