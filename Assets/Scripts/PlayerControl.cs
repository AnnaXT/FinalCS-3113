using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    // public static Player instance;
    
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public FirePoint firePoint;

    Vector2 moveVelocity;
    Vector2 aimVelocity;
    
    Rigidbody rb;
    GameManager _gameManager;
    
    public float moveSpeed;

    private bool shooting;

    private void Start () {
        rb = GetComponent<Rigidbody> ();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(AutoFire(0.1f));
    }

    private void Update()
    {
        // movement
        moveVelocity = new Vector3 (moveJoystick.Horizontal, moveJoystick.Vertical, 0f);
        Vector3 moveInput = new Vector3 (moveVelocity.x, moveVelocity.y, 0f);
        Vector3 moveDir = moveInput.normalized * moveSpeed;
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
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("soul"))
        {
            _gameManager.addSoul(10);
            Destroy(other.gameObject);
        }
    }

    public void GameOver()
    {
        // Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator AutoFire(float waitTime)
    {
        while (true)
        {
            if (shooting)
            {
                firePoint.Shoot();
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
