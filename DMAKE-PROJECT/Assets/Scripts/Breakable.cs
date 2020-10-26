using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour, IDamageable
{
    public int Health {get; set;}

    public int health = 1;

    public GameObject damageEffect;

    public Color effectColor;

    private void Start()
    {
        Health = health;
    }

    public virtual void Damage(int damageAmount)
    {
        GameObject effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = effectColor;

        Health -= damageAmount;

        if(Health <= 0)
        {
            Break();
        }
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
