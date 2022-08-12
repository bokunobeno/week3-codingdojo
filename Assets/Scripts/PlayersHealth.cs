using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersHealth : MonoBehaviour
{
    public static int Health;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount;
    void Awake()
    {
        Health = 10;
        healthText.text = (Health + "/10");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            Health -= 2;
            healthAmount -= 11.5f * Time.deltaTime;
            healthText.text = (Health + "/10");
            healthBar.fillAmount = healthAmount;
            
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
