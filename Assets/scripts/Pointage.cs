using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pointage : MonoBehaviour
{
    public static Pointage instance;
    public TextMeshProUGUI scoreText; // Reference au ui
    private int score = 0; 

     private void Awake()
    {
        // Singleton pattern to ensure there's only one ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdatePointage();
    }

     // pour ajouter les pts
    public void AjoutPts(int points)
    {
        score += points;
        UpdatePointage();
    }
    // pour le ui
    private void UpdatePointage()
    {
        scoreText.text = "Pointage: " + score.ToString();
    }
}
