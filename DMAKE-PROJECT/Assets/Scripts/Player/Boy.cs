﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    [Range(1f, 10f)]
    public float speed = 3f;

    private float distToFollow = 3f;

    private bool moveToPlayer = false;

    private Animator _anim;

    public GameObject arrow;

    [HideInInspector] public bool canFireArrows = false;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (!_anim) Debug.LogError(name + "needs a Animator Component attached to a child object.");

        StartCoroutine(FireArrow(5f));
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, Player.Instance.transform.position) > distToFollow && !moveToPlayer)
        {
            StartCoroutine(MoveToPlayer());
        }
    }

    private IEnumerator MoveToPlayer()
    {
        moveToPlayer = true;

        Vector2 targetPos = Player.Instance.transform.position;

        while (moveToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            _anim.SetBool("isRunning", true);

            if (Vector2.Distance(transform.position, targetPos) < 0.1f) moveToPlayer = false;
            yield return null;
        }

        _anim.SetBool("isRunning", false);
    }

    private IEnumerator FireArrow(float timeBetweenShots)
    {
        while(!canFireArrows)
        {
            yield return null;
        }

        while(canFireArrows)
        {
            yield return new WaitForSeconds(timeBetweenShots);

            Instantiate(arrow, transform.position, Quaternion.identity);
        }
    }
}
