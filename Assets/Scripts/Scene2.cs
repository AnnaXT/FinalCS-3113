using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene2 : MonoBehaviour
{
    public TextMeshProUGUI display_time;
    

    public void Awake()
    {
        display_time.text = Scene1.Anna2.time;
        
    }
    void OnDestroy()
    {
        GameObject obj = GameObject.Find("Scene1Manager"); // Replace "ObjectName" with the name of the GameObject you want to destroy
        Destroy(obj);
    }
}
