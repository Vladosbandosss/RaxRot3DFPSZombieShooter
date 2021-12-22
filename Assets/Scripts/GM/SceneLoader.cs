﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
