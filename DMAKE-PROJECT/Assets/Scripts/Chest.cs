using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    public int health = 1;

    private Animator anim;

    public GameObject heart;
    public GameObject coin;

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
            Open();
        }
    }

    public void Open()
    {
        anim.SetTrigger("open");
        SpawnItem(CalculateItemToSpawn());
    }

    private void SpawnItem(GameObject itemToSpawn)
    {
        Vector3 spawnPos = new Vector2(0, 0.5f);
        Instantiate(itemToSpawn, transform.position + spawnPos, Quaternion.identity);
    }

    private GameObject CalculateItemToSpawn()
    {
        int randNum = Random.Range(0, Player.Instance.Health);

        if (randNum < (Player.Instance.maxHealth) / 4)
        {
            return heart;
        }

        return coin;
    }
}
