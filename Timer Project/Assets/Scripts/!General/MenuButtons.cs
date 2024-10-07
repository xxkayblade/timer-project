using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void RestartGame()
    {
        // reload main game scene?? 
        SceneManager.LoadScene("MainGame");
    }
}
