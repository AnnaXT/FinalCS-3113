using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttoninfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Start ()
    {
        PriceTxt.text = "Price: $" + ShopManager.GetComponent<shopmanager>().shopItems[2,ItemID];
        QuantityTxt.text = ShopManager.GetComponent<shopmanager>().shopItems[3,ItemID].ToString();
    }
}
