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

    public IEnumerator LoadLevelRoutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelRoutine(sceneName, 0));
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    private void Awake()
    {
        _instance = this;
    }
}
