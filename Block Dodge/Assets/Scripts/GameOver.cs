using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text secondsSurvivedUI;
    bool gameOver;

    private void Start()
    {
        // I used to event system because when UI screen doesn't exist player object must be executable.
        // there is no sense of in the PlayerController script has to reference UI script.
        FindObjectOfType<PlayerController>().onPlayerDeath += onGameOver; 
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void onGameOver() {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }

}
