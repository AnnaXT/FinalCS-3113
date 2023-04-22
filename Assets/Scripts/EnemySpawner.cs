using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;
    public float interval = 2f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float waitTime = 2f;

    private float enemy2Chance = 100;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0){
            Spawn1(20);
            waitTime = interval;
            enemy2Chance = Random.Range(0,100);
        }
        if (enemy2Chance < 30){
            Spawn2(10);
            enemy2Chance = Random.Range(0,100);
        }

        
    }

    void Spawn1(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
            float rand1 = Random.Range(-5,5);
            float rand2 = Random.Range(-5,5);

        Vector2 position = new Vector2(x - rand1, y + rand2);
        Instantiate(enemy1, position, Quaternion.identity);
        }

    }
    void Spawn2(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
            float rand1 = Random.Range(-5,5);
            float rand2 = Random.Range(-5,5);

        Vector2 position = new Vector2(x - rand1, y + rand2);
        Instantiate(enemy2, position, Quaternion.identity);
        }

    }
}
