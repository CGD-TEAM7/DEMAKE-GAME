using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateboss : MonoBehaviour
{

    public GameObject hedge, hedge1, hedge2;
    bool bossstart = false;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D playercollider = player.GetComponent<Collider2D>();
        if (collision == playercollider)
        {
            hedge.active = true;
            hedge1.active = true;
            hedge2.active = true;
            Debug.Log("Commence");
        }
    }
   
}
