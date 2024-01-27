using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public int PlayerHealth;

    public GameObject GunBarrel;
    public GameObject Bullet;

    bool isGameOver = true;

    private void Start()
    {
        GameManager.Instance.GameStartEvent += PlayerStart;
        GameManager.Instance.GameOverEvent += PlayerStop;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        SpaceShipMovement(0.05f);

        FireBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy astroid))
        {
            PlayerHealth -= astroid.Damage;

            Destroy(astroid.gameObject);

            if (PlayerHealth <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    void SpaceShipMovement(float movementSensitivity)
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 5)
        {
            transform.position = new Vector2(transform.position.x + movementSensitivity, transform.position.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -5)
        {
            transform.position = new Vector2(transform.position.x - movementSensitivity, transform.position.y);
        }
    }

    void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, GunBarrel.transform.position, Quaternion.identity);
        }
    }

    void PlayerStart()
    {
        PlayerHealth = 20;

        isGameOver = false;
    }

    void PlayerStop()
    {
        isGameOver = true;
    }
}
