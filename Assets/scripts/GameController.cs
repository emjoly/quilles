using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PinManager pinManager; 
    public TextMeshProUGUI gameMessageText; 
    public TextMeshProUGUI scoreText; 
    public Boules boules;

    private int throwCount = 0;
    private int currentScore = 0;
    private bool gameActive = true; 
    private float resetBallTimeout = 5.0f;
    private float lastPinCheckTime;

    private void Awake()
    {
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
        lastPinCheckTime = Time.time; // Initialize the last pin check time
    }

    public void BallThrown()
    {
        if (!gameActive) return;

        throwCount++;
        boules.StartPlay();

        // Check number of throws
        if (throwCount == 1)
        {
            pinManager.CheckPins();
        }
        else if (throwCount == 2)
        {
            pinManager.CheckPins();
            EndGame();
        }

        lastPinCheckTime = Time.time;
    }

public void AllPinsDown()
{
    lastPinCheckTime = Time.time;
    if (throwCount == 1)
    {
        gameMessageText.text = "Strike!";
        currentScore += 10;
        boules.ResetPosition(); 
        pinManager.ResetPins();
        EndGame();
    }
    else if (throwCount == 2)
    {
        gameMessageText.text = "Spare!";
        currentScore += 10;
        EndGame();
    }
}


    private void EndGame()
    {
        if (throwCount == 2 && gameMessageText.text == "")
        {
            
        }

        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        gameActive = false;

        yield return new WaitForSeconds(3.0f);

        pinManager.ResetPins();
        StartNewGame();
    }

    private void StartNewGame()
    {
        throwCount = 0;
        gameActive = true;
        gameMessageText.text = "";
        currentScore = 0;
    }

    private void Update()
    {
        if (boules.IsInPlay() && Time.time - lastPinCheckTime > resetBallTimeout)
        {
            boules.ResetPosition();
        }
    }
}
