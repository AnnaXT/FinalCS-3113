using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    
    public GameObject healthCollectable;
    public GameObject bombCollectable;

    private int maxHC = 5; // max health collectable count
    private int maxBC = 2; // max bomb cillectable count

    // private int currHC = 0;
    // private int currBC = 0;

    private GameObject player;

    void Start()
    {
        print(GameObject.FindGameObjectWithTag("Player"));
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < 5; i++){
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

            isNeg1 = Random.Range(0,10) < 5;
            isNeg2 = Random.Range(0,10) < 5;
            rand1 = Random.Range(0,10);
            rand2 = Random.Range(10 - rand1, 10);
            if (isNeg1){
                rand1 = -rand1;
            }
            if (isNeg2){
                rand2 = -rand2;
            }
            position = new Vector2(x + rand1, y + rand2);
            GameObject newBC = Instantiate(bombCollectable, position, Quaternion.identity);
        }
    //     print("currHC: " + currHC);
    //     print("currBC: " + currBC);
    }

    // void Update()
    // {
    //     if (currHC < maxHC || currBC < maxBC){
    //         float x = player.transform.position.x;
    //         float y = player.transform.position.y;
    //         if (currHC < maxHC){
    //             print("currHC < maxHC");
    //             bool isNeg1 = Random.Range(0,10) < 5;
    //             bool isNeg2 = Random.Range(0,10) < 5;
    //             float rand1 = Random.Range(0,10);
    //             float rand2 = Random.Range(10 - rand1, 10);
    //             if (isNeg1)
    //             {
    //                 rand1 = -rand1;
    //             }
    //             if (isNeg2)
    //             {
    //                 rand2 = -rand2;
    //             }
    //             Vector2 position = new Vector2(x + rand1, y + rand2);
    //             GameObject newHC = Instantiate(healthCollectable, position, Quaternion.identity);
    //             currHC += 1;
    //             print("currHC: " + currHC);
    //         }
    //         if (currBC < maxBC){
    //             print("currBC < maxBC");
    //             bool isNeg1 = Random.Range(0,10) < 5;
    //             bool isNeg2 = Random.Range(0,10) < 5;
    //             float rand1 = Random.Range(0,10);
    //             float rand2 = Random.Range(10 - rand1, 10);
    //             if (isNeg1){
    //                 rand1 = -rand1;
    //             }
    //             if (isNeg2){
    //                 rand2 = -rand2;
    //             }
    //             Vector2 position = new Vector2(x + rand1, y + rand2);
    //             GameObject newBC = Instantiate(bombCollectable, position, Quaternion.identity);
    //             currBC += 1;
    //         }

    //     }
        
    //     //float positionY = Random.Range(5,10);
    //     //float positionX = Random.Range(5,10);
        
    // }

    public void decreaseHC(){
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


    public void decreaseBC(){
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
    }
}

