﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player is null");
            }

            return _instance;
        }
    }

    private SpriteRenderer _sprite;
    private PlayerAnimation _anim;

    public int Health { get; set; }
    [HideInInspector] public int maxHealth = 5;

    [Range(0f, 10f)]
    public float _moveSpeed = 1f;


    private bool isDead = false;
    public bool canThrowAxe = true;

    public int points = 0;

    [SerializeField]
    private GameObject flyingAxePrefab;
    public GameObject axeSprite;

    private bool facingLeft = false;

    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (!_sprite) Debug.LogError(name + " needs a Sprite Renderer Component attached to a child object.");

        _anim = GetComponent<PlayerAnimation>();
        if (!_anim) Debug.LogError(name + " needs Player Animation Script to be attached.");

        Health = maxHealth;
    }


    private void Update()
    {
        if (isDead)
            return;

        Move(_moveSpeed);

        if(Input.GetButtonDown("Fire2") && canThrowAxe)
        {
            ThrowAxe();
        }
    }

    private void Move(float speed)
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveHorizontal, moveVertical).normalized;

        _anim.Move(move.magnitude);

        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (moveHorizontal > 0)
        {
            Flip(gameObject, -1);
            facingLeft = true;
        }
        else if (moveHorizontal < 0)
        {
            Flip(gameObject, 1);
            facingLeft = false;
        }
    }

    public void Damage(int damageAmount)
    {
        if (isDead)
            return;

        Health -= damageAmount;

        UIManager.Instance.UpdateLifeUnits(Health);

        if (Health <= 0)
        {
            _anim.IsDead();
            isDead = true;
        }
    }

    public void AddHealth(int amount)
    {
        if (Health >= maxHealth)
        {
            AddPoints(amount);
        }
        else
        {
            Health += amount;
        }

        UIManager.Instance.UpdateLifeUnits(Health);
    }

    private void Flip(GameObject obj, int direction)
    {
        obj.transform.localScale = new Vector2(direction, transform.localScale.y);
    }

    private void ThrowAxe()
    {
        GameObject flyingAxe = Instantiate(flyingAxePrefab, axeSprite.transform.position, Quaternion.identity);
        if (facingLeft) Flip(flyingAxe, -1);

        EnableAxeSprite(false);
    }

    public void EnableAxeSprite(bool enable)
    {
        axeSprite.GetComponent<SpriteRenderer>().enabled = enable;
        canThrowAxe = enable;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UIManager.Instance.UpdatePointCount(points);
    }
}
