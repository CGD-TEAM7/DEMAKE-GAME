using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreManager : MonoBehaviour
{
    public static FinalScoreManager Instance;


    public int finalScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
