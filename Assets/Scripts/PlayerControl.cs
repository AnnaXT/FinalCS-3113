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


    private void Start () {
        rb = GetComponent<Rigidbody> ();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
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
            firePoint.Shoot();
        }
        else if(aimJoystick.Horizontal <= -0.6f || aimJoystick.Vertical <= -0.6f)
        {
            firePoint.Shoot();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            _gameManager.minusLife();
            if (!other.CompareTag("enemy")){
                Destroy(other.gameObject);
            }
            if (_gameManager.getLife() == 0){
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        // Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
