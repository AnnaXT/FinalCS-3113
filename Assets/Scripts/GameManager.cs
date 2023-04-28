using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int soul = 0;
    public int maxLife = 10;
    int life;
    public int playerSpeed = 5;
    public int bulletSpeed = 10;
    public int dmg = 1;

    string levelName;

    private void Awake()
    {   
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;
    }

    void Start()
    {
        life = maxLife;
    }

    public void minusSoul(int amount)
    {
        soul -= amount;
    }

    public void addSoul(int amount)
    {
        soul += amount;
    }

    public int getSoul(){
        return soul;
    }

    public void minusLife(int amount)
    {
        if (life > 0)
        {
            life -= amount;
        }
    }

    public void addLife(int amount)
    {
        if (life > 0)
        {
            life += amount;
        }
    }

    public int getMaxLife(){
        return maxLife;
    }

    public int getLife(){
        return life;
    }

    public void incrPlayerSpeed(int amount)
    {
        playerSpeed += amount;
    }

    public int getPlayerSpeed(){
        return playerSpeed;
    }

    public void incrBulletSpeed(int amount)
    {
        bulletSpeed += amount;
    }

    public int getBulletSpeed(){
        return bulletSpeed;
    }

    public void incrDmg(int amount)
    {
        dmg += amount;
    }

    public int getDmg(){
        return dmg;
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
        screenChecker();
    }

}