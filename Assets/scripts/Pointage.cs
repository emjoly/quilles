using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pointage : MonoBehaviour
{
    public static Pointage instance;
    public TextMeshProUGUI scoreText;
    private int score = 0; 

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

    void Start()
    {
        UpdatePointage();
    }

    public void AjoutPts(int points)
    {
        score += points;
        UpdatePointage();

        if (score >= 90)
        {
            ResetPins();
        }
    }

    private void UpdatePointage()
    {
        scoreText.text = "Pointage: " + score.ToString();
    }

    private void ResetPins()
    {
        GameController.instance.pinManager.ResetPins();
    }
}
