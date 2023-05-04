using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerControl : MonoBehaviour
{

    // public static Player instance;
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public FirePoint firePoint;
    public HealthBar healthBar;
    public TextMeshProUGUI soulUI;
    public GameObject explosion;

    public AudioClip hurtSnd;
    public AudioClip soulSnd;
    public AudioClip shootSnd;
    public AudioClip clearSnd;
    public AudioClip healSnd;

    Vector2 moveVelocity;
    AudioSource _audioSource;
    Vector2 aimVelocity;
    
    Rigidbody rb;
    // GameManager _gameManager;

    private bool shooting;
    public bool bought = false;
    public int soul = 0;
    public int health = 10;
    public int maxHealth = 10;
    public float playerSpeed = 5;
    public float ammo = 0.5f;
    private float ammoCount = 2; // inverse of ammo

    private Animator _animator;
    private shopmanager _shop;
    private enemy _enemy;
    private ParticleSystem _ps;

    private void Start () {
        rb = GetComponent<Rigidbody> ();
        _shop = GameObject.FindObjectOfType<shopmanager>();
        _enemy = GameObject.FindObjectOfType<enemy>();
        _animator = GetComponent<Animator>();
        _ps = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        
        // _gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(AutoFire(ammo));
        soulUI.text = "" + soul;
        healthBar.setMaxHealthBar(maxHealth);
        healthBar.setHealthBar(health);
    }

    private void Update()
    {
        // movement
        moveVelocity = new Vector3 (moveJoystick.Horizontal, moveJoystick.Vertical, 0f);
        if (moveVelocity[0] == 0 && moveVelocity[1] == 0){
            _animator.SetBool("Flying", false);
        }
        else{
            _animator.SetBool("Flying", true);
        }
        Vector3 moveInput = new Vector3 (moveVelocity.x, moveVelocity.y, 0f);
        Vector3 moveDir = moveInput.normalized * playerSpeed;
        rb.MovePosition (rb.position + moveDir * Time.deltaTime);

        // Aim
        aimVelocity = new Vector3 (aimJoystick.Horizontal, aimJoystick.Vertical, 0f);
        Vector3 AimInput = new Vector3 (aimVelocity.x, aimVelocity.y, 0f);


        if (aimJoystick.Horizontal >= 0.6f || aimJoystick.Vertical >= 0.6f)
        {
            shooting = true;
        }
        else if(aimJoystick.Horizontal <= -0.6f || aimJoystick.Vertical <= -0.6f)
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }

        if (health == 0)
        {
            StartCoroutine(GameOver(0.8f));
            Destroy(moveJoystick);
            Destroy(aimJoystick);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("soul"))
        {
            soul += 10;
            _shop.setCoin(10);
            soulUI.text = "" + soul;
            _audioSource.PlayOneShot(soulSnd);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("enemy") || other.CompareTag("Enemy Bullet"))
        {
            health -= 1;
            _audioSource.PlayOneShot(hurtSnd, 0.5f);
            healthBar.setHealthBar(health);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Clear"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(clearSnd, 0.5f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("health"))
        {
            if ((health + (int)Math.Round(maxHealth * 0.2f)) > maxHealth)
            {
                health = maxHealth;
            } else
            {
                health += (int)Math.Round(maxHealth * 0.2f);
            }
            _ps.Play();
            _audioSource.PlayOneShot(healSnd, 0.5f);
            healthBar.setHealthBar(health);
            Destroy(other.gameObject);
        }

    }

    IEnumerator AutoFire(float waitTime)
    {
        while (true)
        {
            if (shooting)
            {
                firePoint.Shoot();
                _audioSource.PlayOneShot(shootSnd, 0.3f);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void setSouls(int amount)
    {
        soul += amount;
        soulUI.text = "" + soul;
    }

    public void setBuy(bool isBought)
    {
        bought = isBought;
    }

    public void incrHealth()
    {
        if (bought)
        {
            maxHealth += 1;
            if ((health + (int)Math.Round(maxHealth * 0.2f)) > maxHealth)
            {
                health = maxHealth;
            } else
            {
                health += (int)Math.Round(maxHealth * 0.2f);
            }
            healthBar.setMaxHealthBar(maxHealth);
            healthBar.setHealthBar(health);
        }
    }

    public void incrSpeed()
    {
        if (bought)
        {
            playerSpeed += 0.1f;
        }
    }

    public void incrAmmo()
    {
        if (bought)
        {
            ammo = 1 / ( ammoCount + 1 );
            ammoCount += 1;
            StopCoroutine(AutoFire(ammo));
            StartCoroutine(AutoFire(ammo));
        }
    }

    IEnumerator GameOver(float seconds)
    {
        playerSpeed = 0;
        Destroy(GameObject.FindObjectOfType<FixedJoystick>());
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("enemy")){
            Destroy(go);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Clear")){
            Destroy(go);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("health")){
            Destroy(go);
        }
        _animator.Play("PlayerDeath");
        yield return new WaitForSeconds(seconds * Time.timeScale);
        SceneManager.LoadScene("lose");
    }
}
