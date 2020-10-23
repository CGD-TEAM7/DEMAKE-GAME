using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if (!_animator) Debug.LogError(name + "needs a Animator Component attached to a child object.");
    }

    public void Move(float speed)
    {
        _animator.SetFloat("speed", Mathf.Abs(speed));
    }

    public void IsDead()
    {
        _animator.SetTrigger("dead");
    }
}
