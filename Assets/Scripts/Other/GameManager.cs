using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void GameEvent();
    public GameEvent GameStartEvent;
    public GameEvent GameOverEvent;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void GameStart()
    {
        GameStartEvent.Invoke();
    }

    public void GameOver()
    {
        GameOverEvent.Invoke();
    }

}
