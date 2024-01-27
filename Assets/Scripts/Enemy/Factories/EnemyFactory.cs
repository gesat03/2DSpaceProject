using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{

    [SerializeField] BaseEnemy[] Enemies;

    public BaseEnemy CreateEnemy(EEnemyType type)
    {
        switch (type)
        {
            case EEnemyType.SmallAstroid:
                return Enemies[0];
            case EEnemyType.LargeAstroid:
                return Enemies[1];
            case EEnemyType.BasicEnemyShip:
                throw new System.NotImplementedException();
            default:
                return Enemies[0];
        }
    }

    public BaseEnemy CreateRandomEnemy()
    {
        int rand = Random.Range(0, Enemies.Length);

        return Instantiate(Enemies[rand], new Vector2(Random.Range(-5, 5), 8), Quaternion.identity, gameObject.transform);
    }

}
