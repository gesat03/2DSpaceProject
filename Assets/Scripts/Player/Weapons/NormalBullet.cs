using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int Damage;

    private void OnEnable()
    {
        GameManager.Instance.GameOverEvent += GameOver;
    }
    private void OnDisable()
    {
        GameManager.Instance.GameOverEvent -= GameOver;
    }

    void Update()
    {
        BulletMovement(10);

        OutOfBoundry();
    }

    void BulletMovement(float speedMultiplier)
    {
        if (gameObject == null) return;

        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speedMultiplier);
    }

    void OutOfBoundry()
    {
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
    }
}
