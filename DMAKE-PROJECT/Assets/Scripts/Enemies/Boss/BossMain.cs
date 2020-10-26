using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer[] renderers;
    private MoveScript BossMove;
    private WeaponScript BossWeapon;

    private Vector2 TargetPos;

    void float BossHealth = 100.0f;
    public float MinAttackCooldown = 0.5f;
    public float MaxAttackCooldown = 2.0f;
    private float InCooldown;

    public bool isHit = false;
    public bool isAttacking = false;
    public bool isRage = false;
    private bool isSpawned = false;


    void Awake()
    {
        //get weapon (if he has a weapon)
        BossWeapon = GetComponentsInChildren<WeaponScript>();

        //get movement
        BossMove = GetComponent<MoveScript>();

        //get anim
        animator = GetComponent<animator>();

        //get renders
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        //disable all spawns initially
        isSpawned = false;
        GetComponent<Collider2D>().enabled = false;
        BossMove.enabled = false;
        isAttacking = false;
        InCooldown = MaxAttackCooldown;
        //weapon test
        foreach (WeaponScript weapon in BossWeapon)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        if(isSpawned == false)
        {
            if (renderers[0].IsVisableFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            InCooldown -= Time.deltaTime;

            if(InCooldown <= 0.0f)
            {
                isAttacking = !isAttacking;
                InCooldown = Random.Range(MinAttackCooldown, MaxAttackCooldown);
                TargetPos = Vector2.zero;


                //Set anim - idk if im setting up the animations or if someone else is
                animator.SetBool("BossAttack", isAttacking);
            }

            //set attacks
            BossMove.direction = Vector2.zero;
            foreach(WeaponScript weapon in BossWeapon)
            {
                if(weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    //put soundfx code here
                }
            }
        }

       else
        {
            // Define target
            if (TargetPos == Vector2.zero)
            {
                
                Vector2 randomPoint = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

               TargetPos = Camera.main.ViewportToWorldPoint(randomPoint);
            }

            // at target
            if (GetComponent<Collider2D>().OverlapPoint(TargetPos))
            {
                
                TargetPos = Vector2.zero;
            }

            // go to target
            Vector3 direction = ((Vector3)TargetPos - this.transform.position);

            // Boss move scritp
            BossMove.direction = Vector3.Normalize(direction);
        }

    }


    private void Spawn()
    {
        isSpawned = true;

        // Enable everything
        // Collider
        GetComponent<Collider2D>().enabled = true;
        // Moving
        BossMove.enabled = true;
        //Shooting
        foreach (WeaponScript weapon in BossWeapon)
        {
            weapon.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        // if hit
        Player axeSprite = otherCollider2D.gameObject.GetComponent<Playert>();
        if (axeSprite != null)
        {
            if (axeSprite.isHit == true)
            {
                // Stop attacks and start moving bac
                InCooldown = Random.Range(MinAttackCooldown, MaxAttackCooldown);
                isAttacking = false;

                // Change animation
                animator.SetTrigger("BossHit");
            }
        }
    }

 

}