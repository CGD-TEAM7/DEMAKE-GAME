using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : MonoBehaviour
{ 
    public int RockDamage = 1f;
    public bool IsBossRock = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20); //every 20 secs
    }

    
}
