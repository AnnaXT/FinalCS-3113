using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    int health = 20;

    GameManager _gameManager;

    public GameObject soul;

    private void Start () {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "player bullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(soul, transform.position, Quaternion.identity);
            }
        }
    }

}
