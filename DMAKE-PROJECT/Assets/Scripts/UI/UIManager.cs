using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null");
            }

            return _instance;
        }
    }

    public Text pointCountText;
    public Image[] lifeUnits;

    public void UpdatePointCount(int count)
    {
        pointCountText.text = count.ToString();
    }

    public void UpdateLifeUnits(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                lifeUnits[i].enabled = false;
            }
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
