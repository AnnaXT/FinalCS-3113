using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    // public static Player instance;
    
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public FirePoint firePoint;
    public HealthBar healthBar;
    public TextMeshProUGUI soulUI;

    public AudioClip hurtSnd;
    public AudioClip dieSnd;
    public AudioClip shootSnd;

    Vector2 moveVelocity;
    AudioSource _audioSource;
    Vector2 aimVelocity;
    
    Rigidbody rb;
    // GameManager _gameManager;

    private bool shooting;
    public int soul = 1000;
    public int health = 10;
    public int maxHealth = 10;
    public int playerSpeed = 5;
    public float ammo = 0.5f;

    private Animator _animator;
    private shopmanager _shop;

    private void Start () {
        rb = GetComponent<Rigidbody> ();
        _shop = GameObject.FindObjectOfType<shopmanager>();
        _animator = GetComponent<Animator>();
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
            Destroy(gameObject); 
            SceneManager.LoadScene("lose");
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("soul"))
        {
            soul += 10;
            _shop.setCoin(10);
            soulUI.text = "" + soul;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("enemy"))
        {
            health -= 1;
            _audioSource.PlayOneShot(hurtSnd);
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
                _audioSource.PlayOneShot(shootSnd);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void setSouls(int amount)
    {
        soul += amount;
        soulUI.text = "" + soul;
    }

    public void incrHealth()
    {
        maxHealth += 1;
        health += 1;
        healthBar.setMaxHealthBar(maxHealth);
        healthBar.setHealthBar(health);
    }

    public void incrAmmo()
    {
        ammo *= 0.8f;
        StopCoroutine(AutoFire(ammo));
        StartCoroutine(AutoFire(ammo));
    }
}
