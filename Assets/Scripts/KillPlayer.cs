using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //kill kill kill:>
            Die();
        }
    }
    
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
