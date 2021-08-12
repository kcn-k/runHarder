using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    
    public void playGame(){
        Application.LoadLevel(playGameLevel);
    }

    public void quitGame(){
        Application.Quit();
    }
}
