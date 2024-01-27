using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]
public class EnemyGenerator : MonoBehaviour
{
    EnemyFactory _enemyFactory;

    float _timer = 0;
    float _generateTime = 1;

    bool isGameOver = true;

    private void Start()
    {
        _enemyFactory = GetComponent<EnemyFactory>();

        GameManager.Instance.GameStartEvent += StartGenerate;
        GameManager.Instance.GameOverEvent += StopGenerate;
    }

    private void Update()
    {
        if (isGameOver) return;

        GenerateEnemyWithTime();
    }

    void GenerateEnemyWithTime()
    {
        if(_timer > _generateTime)
        {
            _timer = 0;
            _generateTime = Random.Range(1, 1.5f);

            _enemyFactory.CreateRandomEnemy();
        }

        _timer += Time.deltaTime;
    }

    void StartGenerate()
    {
        isGameOver = false;
    }

    void StopGenerate()
    {
        isGameOver = true;
    }

}
