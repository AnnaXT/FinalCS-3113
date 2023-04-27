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

    private float enemy1Speed = 0.5f;
    private int enemy1Health = 3;

    private float enemy2Speed = 1f;
    private int enemy2Health = 2;

    private float enemy3Speed = 0.1f;
    private int enemy3Health = 5;


    private float timeTracker = 0f;
    private float enemy2Chance = 100f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timeTracker += Time.deltaTime;

        //life scaling according to time
        enemy1Health = (int)Mathf.Round(enemy1Health*(1 + (timeTracker/100)));
        print(enemy1Health);
        // speed scaling according to time
        
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
        GameObject enemy = Instantiate(enemy1, position, Quaternion.identity);
        enemy.GetComponent<enemy>().setSpeed(enemy1Speed);
        enemy.GetComponent<enemy>().setHealth(enemy1Health);
        }

    }
    void Spawn2(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
            float rand1 = Random.Range(-5,5);
            float rand2 = Random.Range(-5,5);

        Vector2 position = new Vector2(x - rand1, y + rand2);
        GameObject enemy = Instantiate(enemy2, position, Quaternion.identity);
        enemy.GetComponent<enemy>().setSpeed(enemy1Speed);
        enemy.GetComponent<enemy>().setHealth(enemy1Health);
        }

    }
}
