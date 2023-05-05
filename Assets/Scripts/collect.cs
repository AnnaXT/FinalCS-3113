using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    Vector2 floatY;
    float originalY;
    public GameObject explosion;
    public GameObject collectableSpawner;
    public GameObject tileGenerator;

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
        print("entered collect");
        if (other.CompareTag("Player")){
            //Instantiate(explosion, transform.position, Quaternion.identity);
            if (this.CompareTag("health")){
                print("got health");
                Destroy(this);
                collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC(1);
            }
            else if (this.CompareTag("Clear")){
                print("cleared screen");
                Destroy(this);
                collectableSpawner.GetComponent<CollectableSpawner>().decreaseBC(1);
            //tileGenerator.GetComponent<TileGenerator>().randChangeZone();
        }
            //Destroy(this);
        }
    }
}
