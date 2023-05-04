using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeCollectable : MonoBehaviour
{
    public float time = 20;
    public GameObject collectableSpawner;

    void Start()
    {

    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0){
            if (this.CompareTag("health")){
               collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC();
            }
            else if (this.CompareTag("Clear")){
                collectableSpawner.GetComponent<CollectableSpawner>().decreaseBC();
            }
            Destroy(this);
        }
        
    }
}
