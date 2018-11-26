using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        //only allow 1 game session
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
