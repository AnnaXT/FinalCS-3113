using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody _rigidbody;
    private GameObject player;
    public float speed = 0.2f;

    private bool chase = true;
    public float interval = 2f;
    private float waitTime = 2f;
    //GameManager _gameManager;

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.GameObject.tag == "bullet")
    //     {
    //         Destroy(collision.GameObject);
    //     }
    // }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
        //_gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase == false){
            waitTime -= Time.deltaTime;
        }
        else{
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
        if (waitTime <= 0){
            waitTime = interval;
            chase = true;
        }
        
    }

    // private void OnTriggerEnter(Collider other){
    //     if (other.CompareTag("Player")){
    //         //other.GetComponent<PlayerHealth>().ChangeLifeVal(-1);
    //         _gameManager.UpdateLives(-1);
    //         chase = false;
            
    //     }

    // }
}
