using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    void Start() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void Quit(){
        Application.Quit();
    }

    public void TryAgain(){
        PlayerPrefs.SetInt("level",1);
        PlayerPrefs.SetInt("Coin", 10);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }
}
