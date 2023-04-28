using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody _rigidbody;
    private GameObject player;
    public HealthBar healthBar;
    public GameObject soul;
    public float speed = 0.2f;
    private int maxHealth = 2;
    int health;

    private bool chase = true;
    public float interval = 2f;
    private float waitTime = 2f;

    private Animator _animator;
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
        _animator = gameObject.GetComponent<Animator>();

        health = maxHealth;
        GameObject temp = gameObject.transform.Find("Canvas (1)/Health Bar").gameObject;
        healthBar = temp.GetComponent<HealthBar>();
        healthBar.setMaxHealthBar(maxHealth);

        //_gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerY = player.transform.position.y;
        if (playerY >= transform.position.y){
            _animator.SetBool("Above", false);
        }
        else{
            _animator.SetBool("Above", true);
        }
        if (chase == false){
            waitTime -= Time.deltaTime;
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
        if (waitTime <= 0){
            waitTime = interval;
            chase = true;
        }
        
    }

    public void changeSpeed(float val){
        speed += val;
    }

    public void setSpeed(float val){
        speed = val;
    }

    public void changeHealth(int val){
        health += val;
        healthBar.setHealthBar(health);
    }

    public void setHealth(int val){
        health = val;
        healthBar.setMaxHealthBar(maxHealth);
    }

    public int getHealth(){
        return health;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("player bullet")){
            print(health);
            Destroy(other.gameObject);
            changeHealth(-1);
            healthBar.setHealthBar(health);
            if (health == 0){
                Destroy(gameObject);
                Instantiate(soul, transform.position, Quaternion.identity);
            }
        }
    }
}
