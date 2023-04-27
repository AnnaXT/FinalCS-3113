using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int soul = 0;
    string levelName;

    public TMPro.TextMeshProUGUI soulUI;

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
        soulUI.text = "" + soul;
    }

    public void minusSoul(int amount)
    {
        soul -= amount;
        soulUI.text = "" + soul;
    }

    public void addSoul(int amount)
    {
        soul += amount;
        soulUI.text = "" + soul;
    }

    public float getSoul(){
        return soul;
    }

    // public void minusLife(int amount)
    // {
    //     if (life > 0)
    //     {
    //         life -= amount;
    //         if (life == 0){
    //             GameOver = true;
    //         }
    //     }
    // }

    // public void addLife(int amount)
    // {
    //     if (life > 0)
    //     {
    //         life += amount;
    //     }
    // }

    // public int getLife(){
    //     return life;
    // }

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
        soul = 0;
        SceneManager.LoadScene("GameOver");
    }
}