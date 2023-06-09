using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody _rigidbody;
    AudioSource _audioSource;
    private GameObject player;
    public HealthBar healthBar;
    public GameObject soul;
    public GameObject explosion;
    public AudioClip dieSnd;
    public float speed = 0.2f;
    public int bulletDmg = 1;
    int maxHealth = 2;
    int health = 2;

    private bool chase = true;
    public float interval = 2f;
    private float waitTime = 2f;

    private Animator _animator;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
        _animator = gameObject.GetComponent<Animator>();

        health = maxHealth;
        GameObject temp = gameObject.transform.Find("Canvas (1)/Health Bar").gameObject;
        _audioSource = GetComponent<AudioSource>();
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

    public int getBulletDmg(){
        return bulletDmg;
    }

    public void setBulletDmg(int val){
        bulletDmg += val;
    }

    public void setHealth(int val){
        //print("reset health");
        health = val;
        maxHealth = val;
        print(healthBar.GetComponent<HealthBar>());
        healthBar.GetComponent<HealthBar>().setMaxHealthBar(maxHealth);
        healthBar.GetComponent<HealthBar>().setHealthBar(health);
        //healthBar.setMaxHealthBar(maxHealth);
        //healthBar.setHealthBar(health);
    }

    public int getHealth(){
        return health;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("player bullet")){
            print(health);
            _audioSource.PlayOneShot(dieSnd, 1);
            Destroy(other.gameObject);
            changeHealth(-bulletDmg);
            healthBar.setHealthBar(health);
            if (health == 0){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Instantiate(soul, transform.position, Quaternion.identity);
            }
        }
    }
}
