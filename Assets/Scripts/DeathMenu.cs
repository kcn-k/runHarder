﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;

    public void restartGame(){
        FindObjectOfType<GameManager>().reset();
    }

    public void quitToMain(){
        Application.LoadLevel(mainMenu);
    }
}
