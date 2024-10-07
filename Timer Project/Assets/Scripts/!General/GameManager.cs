using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Timer")]
    [SerializeField] Slider timerBar;
    [SerializeField] float gameOver = 0f;

    [Header("Menus")]
    public GameObject gameOverMenu;
    public PlayerMovement playerScript;
    public TextMeshProUGUI displayScore;
    public int score = 0;


    // [SerializeField] float addedTime; 

    // void Awake?
    // if game scene active
    // timer start
    // when timer zero, game over screen
    // when item collected, time added to timer

    void Update()
    {
        if (timerBar != null)
        {
            if ((timerBar.value <= 60) && (gameOverMenu.activeSelf == false))
            {
                timerBar.value -= Time.deltaTime;

                if (timerBar.value <= gameOver)
                {
                    GameOver();
                }
            }
        }

        score = playerScript.enemiesDefeated;
        displayScore.text = playerScript.enemiesDefeated.ToString();
    }

    void GameOver()
    {
        // game over screen active
        gameOverMenu.SetActive(true);
    }

}
