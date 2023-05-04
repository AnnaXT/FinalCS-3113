using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Shoot : MonoBehaviour
{
    public GameObject bullet;

    private GameObject player;
    private float interval = 2;
    private float time = 2;
    Vector3 direction;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        transform.LookAt(player.transform);
        if (time <= 0){
            time = interval;
            //direction = (transform.localRotation * Vector2.right).normalized;
            direction = new Vector3(player.transform.position.x-transform.position.x, player.transform.position.y-transform.position.y, 0f).normalized;
            GameObject go = Instantiate (bullet, transform.position, Quaternion.identity);
            Bullet goBullet = go.GetComponent<Bullet> ();
            goBullet.direction = direction;
        }
        
    }
}
