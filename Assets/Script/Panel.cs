using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public static int level;
    public int maxLevel = 3;
    public GameObject[] levelUnlocked;
    public static int coin;
    public Text getCoin;
    public string getLevel;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level");
        getLevel = "level1";
        coin = PlayerPrefs.GetInt("Coin");
        getCoin.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 1 ; i< maxLevel ; i++){
            if( i <= level ){
                levelUnlocked[i].SetActive(false);
            }
            else{
                levelUnlocked[i].SetActive(true);
            }
        }

        if(PlayerPrefs.GetInt("level") == 4){
            PalyerWin();
        }
    }

    public void LoadLevel(string le){
        // clickLevel.Play();
        getLevel = "level"+ (PlayerPrefs.GetInt("level")).ToString();
        if(getLevel == le){
           SceneManager.LoadScene(le); 
        }
    }

    public void ResetGame(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }

    public void PalyerWin(){
        SceneManager.LoadScene("Win");
    }

    public void Quit(){
        Application.Quit(); 
    }

    public void Help(){
         SceneManager.LoadScene("Help");
    }
}
