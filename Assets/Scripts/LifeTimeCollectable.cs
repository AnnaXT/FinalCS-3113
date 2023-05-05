using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeCollectable : MonoBehaviour
{
    public float maxTime = 10f;
    public float time = 10f;
    //public GameObject collectableSpawner;

    public GameObject healthCollectable;
    public GameObject bombCollectable;
    private GameObject player;
    private bool added = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(timer());
        Destroy(gameObject,10);
    }

    //void Update()
    //{
        // time -= Time.deltaTime;
        // if (time <= 0f && ! added){
        //     if (this.CompareTag("health")){
        //         print("AddedHC");
        //         added = true;
        //         float x = player.transform.position.x;
        //         float y = player.transform.position.y;
        //         bool isNeg1 = Random.Range(0,10) < 5;
        //         bool isNeg2 = Random.Range(0,10) < 5;
        //         float rand1 = Random.Range(0,10);
        //         float rand2 = Random.Range(10 - rand1, 10);
        //         if (isNeg1)
        //         {
        //             rand1 = -rand1;
        //         }
        //         if (isNeg2)
        //         {
        //             rand2 = -rand2;
        //         }
        //         Vector2 position = new Vector2(x + rand1, y + rand2);
        //         GameObject newHC = Instantiate(healthCollectable, position, Quaternion.identity);
        //         //collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC();
        //     }
        //     else if (this.CompareTag("Clear")){
        //         print("AddedBC");
        //         added = true;
        //         float x = player.transform.position.x;
        //         float y = player.transform.position.y;
        //         bool isNeg1 = Random.Range(0,10) < 5;
        //         bool isNeg2 = Random.Range(0,10) < 5;
        //         float rand1 = Random.Range(0,10);
        //         float rand2 = Random.Range(10 - rand1, 10);
        //         if (isNeg1){
        //             rand1 = -rand1;
        //         }
        //         if (isNeg2){
        //             rand2 = -rand2;
        //         }
        //         Vector2 position = new Vector2(x + rand1, y + rand2);
        //         GameObject newBC = Instantiate(bombCollectable, position, Quaternion.identity);
        //         //collectableSpawner.GetComponent<CollectableSpawner>().decreaseBC();
        //     }
        //     Destroy(this);
        //     time = maxTime;
        // }
    //}

    IEnumerator timer(){
        yield return new WaitForSeconds(10);
        if (this.CompareTag("health")){
            print("AddedHC");
            added = true;
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
            //collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC();
        }
        else if (this.CompareTag("Clear")){
            print("AddedBC");
            added = true;
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
        }
        Destroy(this);

    }

    
                
                
}
