using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    public GameObject soul;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            KillAll();
        }
    }
    
    public void KillAll() {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("enemy")){
            Instantiate(soul, go.transform.position, Quaternion.identity);
            Destroy(go);
        }
    }
}
