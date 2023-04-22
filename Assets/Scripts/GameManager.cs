using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int coin = 0;
    int life = 5;
    string levelName;

    public TMPro.TextMeshProUGUI coinUI;
    public TMPro.TextMeshProUGUI lifeUI;

    private bool GameOver = false;

    private void Awake()
    {   
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;

        // if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        // {
        //     //print(GameObject.FindObjectsOfType<GameManager>());
        //     Destroy(gameObject);
        // }
        // else
        // {
        // DontDestroyOnLoad(gameObject);
        // }
    }

    void Start()
    {
        coinUI.text = "COIN: " + coin;
        lifeUI.text = "LIFE: " + life;
    }

    public void minusCoin(int amount)
    {
        coin -= amount;
        coinUI.text = "COIN: " + coin;
    }

    public void addCoin(int amount)
    {
        coin += amount;
        coinUI.text = "COIN: " + coin;
    }

    public float getCoin(){
        return coin;
    }

    public void minusLife()
    {
        if (life > 0)
        {
            life -= 1;
            lifeUI.text = "LIFE: " + life;
            if (life == 0){
                GameOver = true;
            }
        }
    }

    public void addLife()
    {
        if (life > 0)
        {
            life += 1;
            lifeUI.text = "LIFE: " + life;
        }
    }

    public int getLife(){
        return life;
    }

    void screenChecker()
    {
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
    void Update()
    {
        if (GameOver){
            StartCoroutine(swapToLost());
            GameOver = false;
        }
        screenChecker();
    }

    IEnumerator swapToLost() {
        yield return new WaitForSeconds(1);
        coin = 0;
        life = 5;
        SceneManager.LoadScene("GameOver");
    }
}