using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    private Image timeBar;
    public float maxTime = 2f;
    float timeLeft ;

    void Start()
    {
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
        PlayerPrefs.SetInt("level",1);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if(timeLeft> 0){
            timeLeft -=Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else{
            SceneManager.LoadScene("Menu");
        }
        
    }
}
