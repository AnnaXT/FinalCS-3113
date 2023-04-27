using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armFollow : MonoBehaviour
{
    public GameObject player;

    // copied from firing
    public FixedJoystick aimJoystick;
    //

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 moveVector = (-(Vector3.up * aimJoystick.Horizontal + Vector3.left * aimJoystick.Vertical));
        if (aimJoystick.Horizontal != 0 || aimJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }
}
