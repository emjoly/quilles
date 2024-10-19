using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PinManager pinManager; // Ref au PinManager script
    public TextMeshProUGUI gameMessageText; // Text UI Strike, Spare
    public TextMeshProUGUI scoreText; // Text UI  score

    private int throwCount = 0; // track cmb de lancer ont été fait
    private int currentScore = 0; // Current score
    private bool gameActive = true; 

    private void Awake()
    {
        // Singleton pattern for GameController
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartNewGame();
    }

    // appeler quand joueuer lance la boule
    public void BallThrown()
    {
        if (!gameActive) return;

        throwCount++;

        // Checker le nmb de lancer
        if (throwCount == 1)
        {
            // premier lancer, check pour strike
            pinManager.CheckPins();
        }
        else if (throwCount == 2)
        {
            // 2e lancer, check pour spare
            pinManager.CheckPins();
            EndGame();
        }
    }

    // appeler quand toutes les pins sont tombées
    public void AllPinsDown()
    {
        if (throwCount == 1)
        {
            // Strike si cets le premier lancer
            gameMessageText.text = "Strike!";
            currentScore += 10; // score
            EndGame();
        }
        else if (throwCount == 2)
        {
            // Spare si cest le 2e lancer
            gameMessageText.text = "Spare!";
            currentScore += 10; // Add score for spare
            EndGame();
        }
    }

    private void EndGame()
    {
        // Display score if no strike or spare
        if (throwCount == 2 && gameMessageText.text == "")
        {
            gameMessageText.text = "Score: " + currentScore;
        }

        // Reset the game after a short delay
        StartCoroutine(ResetGame()); // This triggers the pin reset after a delay
    }

    private IEnumerator ResetGame()
    {
        gameActive = false;

        // Wait for a few seconds to display the message
        yield return new WaitForSeconds(3.0f);

        // Reset everything for the next game
        pinManager.ResetPins();
        StartNewGame();
    }

    private void StartNewGame()
    {
        // Reset throw count, game state, and message text
        throwCount = 0;
        gameActive = true;
        gameMessageText.text = "";
    }
}
