using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Bullet bullet;
    public FixedJoystick aimJoystick;

    Vector3 aimVelocity;
    Vector3 direction;
    
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;

        aimVelocity = new Vector3 (aimJoystick.Horizontal, aimJoystick.Vertical, 0f);
        Vector3 AimInput = new Vector3 (aimVelocity.x, aimVelocity.y, 0f);
        direction =  AimInput;
    }

    public void Shoot()
    {
        GameObject go = Instantiate (bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet> ();
        goBullet.direction = direction;
    }
}
