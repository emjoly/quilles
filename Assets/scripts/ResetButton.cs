using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Boules ball;

    public void OnResetButtonPressed()
    {
        if (ball != null)
        {
            ball.ResetPosition();
        }
    }
}