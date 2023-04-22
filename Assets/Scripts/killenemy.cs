using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    int health = 100;

    GameManager _gameManager;

    private void Start () {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
            _gameManager.addCoin(1);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
