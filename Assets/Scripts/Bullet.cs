using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 velocity;

    public int bulletSpeed = 10;

    // GameManager _gameManager;

    void Start()
    {   
        // _gameManager = GameObject.FindObjectOfType<GameManager>();
        Destroy(gameObject, 1);
    }

    void Update()
    {
        velocity = direction * bulletSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
