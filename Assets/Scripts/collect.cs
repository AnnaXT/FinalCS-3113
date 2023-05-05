using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    Vector2 floatY;
    float originalY;
    public GameObject explosion;
    //public GameObject collectableSpawner;
    public GameObject tileGenerator;

    public float floatStrength;


    /////
    public GameObject healthCollectable;
    public GameObject bombCollectable;
    private GameObject player;
    /////

    void Start ()
    {
        this.originalY = this.transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
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
                //collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC();
                float x = player.transform.position.x;
                float y = player.transform.position.y;
                bool isNeg1 = Random.Range(0,10) < 5;
                bool isNeg2 = Random.Range(0,10) < 5;
                float rand1 = Random.Range(0,10);
                float rand2 = Random.Range(10 - rand1, 10);
                if (isNeg1)
                {
                    rand1 = -rand1;
                }
                if (isNeg2)
                {
                    rand2 = -rand2;
                }
                Vector2 position = new Vector2(x + rand1, y + rand2);
                GameObject newHC = Instantiate(healthCollectable, position, Quaternion.identity);
            }
            else if (this.CompareTag("Clear")){
                print("cleared screen");
                Destroy(this);
                float x = player.transform.position.x;
                float y = player.transform.position.y;
                bool isNeg1 = Random.Range(0,10) < 5;
                bool isNeg2 = Random.Range(0,10) < 5;
                float rand1 = Random.Range(0,10);
                float rand2 = Random.Range(10 - rand1, 10);
                if (isNeg1){
                    rand1 = -rand1;
                }
                if (isNeg2){
                    rand2 = -rand2;
                }
                Vector2 position = new Vector2(x + rand1, y + rand2);
                GameObject newBC = Instantiate(bombCollectable, position, Quaternion.identity);
                //collectableSpawner.GetComponent<CollectableSpawner>().decreaseBC();
            //tileGenerator.GetComponent<TileGenerator>().randChangeZone();
        }
            //Destroy(this);
        }
    }
}
