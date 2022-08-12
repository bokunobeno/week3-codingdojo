using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    PlayerMovements _playerJumpScript;
    public static int coinsCollected = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    private void Start()
    {
        _playerJumpScript = GetComponent<PlayerMovements>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _playerJumpScript.soundManager.PlayCoinCollect();
            coinsCollected++;
            if(coinText != null)
            {
                coinText.text = ("" + coinsCollected);
            }
            if (coinsCollected >= 20)
            {
                _playerJumpScript.soundManager.PlayWinSound();
            }
            Destroy(other.gameObject);
        }
        
    }
   
}
