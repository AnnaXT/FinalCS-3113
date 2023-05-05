using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeCollectable : MonoBehaviour
{
    public float maxTime = 20f;
    public float time = 20f;
    public GameObject collectableSpawner;

    void Start()
    {

    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f){
            if (this.CompareTag("health")){
                collectableSpawner.GetComponent<CollectableSpawner>().decreaseHC(1);
            }
            else if (this.CompareTag("Clear")){
                collectableSpawner.GetComponent<CollectableSpawner>().decreaseBC(1);
            }
            Destroy(this);
            time = maxTime;
        }
    }

    
                
                
}
