using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int _damageAmount = 1;

    private bool _canDamage = true;

    [SerializeField] private float timeBetweenAttacks = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage(_damageAmount);
                StartCoroutine(DamageRoutine());
            }
        }
    }

    private IEnumerator DamageRoutine()
    {
        _canDamage = false;
        yield return new WaitForSeconds(timeBetweenAttacks);
        _canDamage = true;
    }
}
