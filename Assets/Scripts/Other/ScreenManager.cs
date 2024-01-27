using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameStartPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GameStartEvent += GameStart;
        GameManager.Instance.GameOverEvent += GameOver;

        GameStartPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    void GameStart()
    {
        GameStartPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

}
