using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public Transform RockPrefab;
    public float FireRate = 0.20f;

    private float RockCooldown;

    // Start is called before the first frame update
    void Start()
    {
        RockCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (RockCooldown > 0)
        {
            RockCooldown -= Timeout.deltaTime;
        }
    }

    public void BossAttack(bool IsBoss)
    {
        if (BossCanAttack)
        {
            RockCooldown = FireRate;

            //make new shot
            var RockTransform = Instantiate(RockPrefab) as Transform;
            //set pos 
            RockTransform.position = transform.position;

            //shot is from the boss only 
            RockScript Rock = RockTransform.gameObject.GetComponent<RockScript>();
            if (Rock != null)
            {
                Rock.IsBossRock = IsBoss;
            }

            //need to position where shot comes from bcz rn is a mess c:
        }
    }


    public bool BossCanAttack
    {
        get
        {
            return RockCooldown <= 0f;
        }
    }
}