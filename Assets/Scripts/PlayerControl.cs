using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public FirePoint firePoint;

    Vector2 moveVelocity;
    Vector2 aimVelocity;
    
    private Rigidbody rb;
    
    public float moveSpeed;
    // public float fireSpeed;


    private void Start () {
        rb = GetComponent<Rigidbody> ();
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
        
        if (aimJoystick.Horizontal != 0 && aimJoystick.Vertical != 0.0f)
        {
            firePoint.Shoot();
        }

        // if (aimJoystick.Horizontal >= 0.6f || aimJoystick.Vertical >= 0.6f)
        // {
        //     firePoint.Shoot();
        // }
        // else if(aimJoystick.Horizontal <= -0.6f || aimJoystick.Vertical <= -0.6f)
        // {
        //     firePoint.Shoot();
        // }
    }
}
