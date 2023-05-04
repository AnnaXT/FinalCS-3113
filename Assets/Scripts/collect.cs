using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    Vector2 floatY;
    float originalY;
    public GameObject explosion;

    public float floatStrength;

    void Start ()
    {
        this.originalY = this.transform.position.y;
    }

    void Update () {
        floatY = transform.position;
        floatY.y = originalY + (Mathf.Sin(Time.time) * floatStrength);
        transform.position = floatY;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
