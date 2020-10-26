using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    public int health = 1;

    public GameObject damageEffect;

    public Color effectColor;

    public GameObject coin;

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

        if (Health <= 0)
        {
            Break();
        }
    }

    public void Break()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
