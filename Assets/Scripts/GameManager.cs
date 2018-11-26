using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    int score; 

    private void Awake()
    {
        Debug.Log("Scene Manager awake");
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public int GetScore()
    {
        return score;
    }

    public void addScore(int num)
    {
        score += num;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
