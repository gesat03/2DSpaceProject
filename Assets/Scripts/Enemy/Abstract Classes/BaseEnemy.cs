using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    public int Health;
    public int Damage;
    public float MovementSpeed;

    private void Start()
    {
        GameManager.Instance.GameOverEvent += GameOver;
    }
    private void OnDisable()
    {
        GameManager.Instance.GameOverEvent -= GameOver;
    }

    protected abstract void Update();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NormalBullet bullet))
        {
            Health -= bullet.Damage;

            Destroy(bullet.gameObject);

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    protected void EnemyMovement()
    {
        if (gameObject == null) return;

        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * MovementSpeed);
    }

    protected void OutOfBoundry()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    protected void GameOver()
    {
        Destroy(gameObject);
    }

}
