using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerImg;

    [SerializeField] private float timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        timerImg.fillAmount = timeLeft;
        StartCoroutine(Countdown());
        
    }


    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            timeLeft-= 0.02f;
            timerImg.fillAmount = timeLeft;
            if (timeLeft <= 0.5 && timeLeft > 0.3)
            {
                //change to blue
                timerImg.color = new Color32(49,255,251,255);
            }
            else if(timeLeft <= 0.3)
            {
                //change to red
                timerImg.color = new Color32(255,50,61,255);
            }

            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }
}
