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
    private float enemy3Chance = 100f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timeTracker += Time.deltaTime;
        //print(timeTracker);

        //life scaling according to time
        // Maybe use Mathf.Pow(float, power) to do scaling
        enemy1Health = (int)Mathf.Round(3*(1 + (timeTracker/50)));
        enemy2Health = (int)Mathf.Round(2*(1 + (timeTracker/50)));
        enemy3Health = (int)Mathf.Round(5*(1 + (timeTracker/50)));

        // speed scaling according to time
        enemy1Speed = 0.5f*(1 + (timeTracker/50));
        enemy2Speed = 1f*(1 + (timeTracker/50));
        enemy3Speed = 0.1f*(1 + (timeTracker/50));
        
        waitTime -= Time.deltaTime;
        if (waitTime <= 0){
            // use exponential here maybe as well
            Spawn1((int)timeTracker);
            waitTime = interval;
            enemy2Chance = Random.Range(0,100);
        }
        if (enemy2Chance < 30){
            Spawn2((int)(timeTracker*0.5f));
            enemy2Chance = 100f;
            enemy3Chance = Random.Range(0,100);
        }
        if (enemy3Chance < 30){
            Spawn3((int)(timeTracker*0.1f));
            enemy3Chance = 100f;
        }
        
    }

    void Spawn1(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
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
        GameObject enemy = Instantiate(enemy1, position, Quaternion.identity);
        enemy.GetComponent<enemy>().setSpeed(enemy1Speed);
        enemy.GetComponent<enemy>().setHealth(enemy1Health);
        }

    }
    void Spawn2(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
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

        Vector2 position = new Vector2(x - rand1, y + rand2);
        GameObject enemy = Instantiate(enemy2, position, Quaternion.identity);
        enemy.GetComponent<enemy>().setSpeed(enemy2Speed);
        enemy.GetComponent<enemy>().setHealth(enemy2Health);
        }

    }

    void Spawn3(int limit){

        float x = player.transform.position.x;
        float y = player.transform.position.y;

        for (int i = 0; i < Random.Range(0,limit); i++){
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

        Vector2 position = new Vector2(x - rand1, y + rand2);
        GameObject enemy = Instantiate(enemy3, position, Quaternion.identity);
        enemy.GetComponent<enemy>().setSpeed(enemy3Speed);
        enemy.GetComponent<enemy>().setHealth(enemy3Health);
        }

    }
}
