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

    public Text timerText;

    public Text dialogText;

    public Image dialogImage;

    private const float dialogTextTime = 0.15f;
    private const float dialogTextTimeLong = 2.0f;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(DialogRoutine("Follow me into the woods boy",
    "It  is  time  you  showed  me  what  you  know  about  hunting"));
    }

    public void UpdateTimerText(float time)
    {
        var minutes = time / 60;
        var seconds = time % 60;

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void UpdatePointCount(int count)
    {
        pointCountText.text = count.ToString();
    }

    public void UpdateLifeUnits(int livesRemaining)
    {
        for (int i = 0; i < lifeUnits.Length; i++)
        {
            if (i < livesRemaining)
            {
                lifeUnits[i].enabled = true;
            }
            else
            {
                lifeUnits[i].enabled = false;
            }
        }
    }

    IEnumerator DialogRoutine(string text)
    {
        dialogText.text = "";
        dialogImage.enabled = true;
        Player.Instance.enabled = false;

        string[] strArray = text.Split(" "[0]);

        for (int i = 0; i < strArray.Length; i++)
        {
            dialogText.text += strArray[i] + " ";
            yield return new WaitForSeconds(dialogTextTime);
        }

        yield return new WaitForSeconds(dialogTextTimeLong);

        dialogText.text = "";
        dialogImage.enabled = false;
        Player.Instance.enabled = true;
    }

    IEnumerator DialogRoutine(string text, string text2)
    {
        dialogText.text = "";
        dialogImage.enabled = true;
        Player.Instance.enabled = false;

        string[] strArray = text.Split(" "[0]);

        for (int i = 0; i < strArray.Length; i++)
        {
            dialogText.text += strArray[i] + " ";
            yield return new WaitForSeconds(dialogTextTime);
        }

        yield return new WaitForSeconds(dialogTextTimeLong);

        strArray = text2.Split(" "[0]);
        dialogText.text = "";

        for (int i = 0; i < strArray.Length; i++)
        {
            dialogText.text += strArray[i] + " ";
            yield return new WaitForSeconds(dialogTextTime);
        }

        yield return new WaitForSeconds(dialogTextTimeLong);

        dialogText.text = "";
        dialogImage.enabled = false;
        Player.Instance.enabled = true;
    }
}
