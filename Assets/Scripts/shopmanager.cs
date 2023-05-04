using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class shopmanager : MonoBehaviour
{
    public int[,] shopItems = new int [5,5];
    public float coins = 0;
    public float outsidecoins = 0;
    public AudioClip shopSnd;
    public AudioClip brokeSnd;
    public Text CoinsTXT;
    public TextMeshProUGUI outsidecoinsTXT;
    
    private PlayerControl _player;
    AudioSource _audioSource;

    void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerControl>();
        _audioSource = GetComponent<AudioSource>();
        CoinsTXT.text = "Coins: " + coins;

        // IDs
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        // Price
        shopItems[2,1] = 10;
        shopItems[2,2] = 20;
        shopItems[2,3] = 30;
        shopItems[2,4] = 40;

        // Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID])
        {
            _audioSource.PlayOneShot(shopSnd, 0.5f);
            coins -= shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID];
            // outsidecoins = coins;
            _player.setSouls(-shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID]);
            shopItems[3, ButtonRef.GetComponent<buttoninfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            outsidecoinsTXT.text = (coins).ToString();
            ButtonRef.GetComponent<buttoninfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<buttoninfo>().ItemID].ToString();
            shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID] *= 2;
            ButtonRef.GetComponent<buttoninfo>().PriceTxt.text = shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID].ToString();
            _player.setBuy(true);
        }
        else {
            _audioSource.PlayOneShot(brokeSnd, 1);
            _player.setBuy(false);
        }
    }

    public void setCoin(int amount)
    {
        coins += amount;
        CoinsTXT.text = "Coins: " + coins;
    }
}
