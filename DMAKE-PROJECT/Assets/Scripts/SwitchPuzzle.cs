using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    private int health = 1;

    private Animator anim;

    public Animator gateAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (!anim) Debug.LogError(name + "needs a Animator Component.");

        Health = health;
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            ActivateGate();
        }
    }

    public void ActivateGate()
    {
        anim.SetTrigger("switch");
        gateAnim.SetTrigger("open");
    }
}
