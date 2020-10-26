using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCave : MonoBehaviour
{
    public GameObject wolfPrefab;

    public float minPlayerDistance = 5f;

    public float timeBetweenSpawns = 1.5f;

    private int spawnCount;
    private int amountToSpawn = 3;

    IEnumerator SpawnWolfs()
    {
        while(!Player.Instance.isDead)
        {
            while (Vector2.Distance(transform.position, Player.Instance.transform.position) > minPlayerDistance)
            {
                yield return null;
            }

            while (spawnCount < amountToSpawn && Vector2.Distance(transform.position, Player.Instance.transform.position) < minPlayerDistance)
            {
                Instantiate(wolfPrefab, transform.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnWolfs());
    }
}
