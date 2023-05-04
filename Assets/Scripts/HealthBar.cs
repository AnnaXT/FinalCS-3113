using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Start(){
        slider = gameObject.GetComponent<Slider>();
    }

    public void setMaxHealthBar(int health)
    {
        //print("maxHset");
        //print(health);
        slider.maxValue = health;
        // slider.value = health;

    }

    public void setHealthBar(int health)
    {
        //print("valSet");
        //print(health);
        slider.value = health;
    }
}
