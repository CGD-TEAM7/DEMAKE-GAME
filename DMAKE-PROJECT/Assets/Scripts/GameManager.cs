using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null");
            }

            return _instance;
        }
    }

    public IEnumerator LoadMainMenu(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator LoadLevel(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        _instance = this;
    }
}
