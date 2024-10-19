using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public List<GameObject> pins; // List to hold all pin GameObjects
    private int totalPins;  // nmb de pins
    private int knockedDownPins; // compteur de pins tombées

    private void Start()
    {
        // Find all pin GameObjects in the scene and add them to the list
        pins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pin"));
        totalPins = pins.Count;
    }

    public void CheckPins()
    {
        knockedDownPins = 0;
        // Check if all pins are down
        foreach (GameObject pin in pins)
        {
            if (!pin.activeSelf) // si la pin est tombée
            {
                knockedDownPins++;
            }
        }

       // si toutes le pins sont tombées
        if (knockedDownPins == totalPins)
        {
            GameController.instance.AllPinsDown();
        }
    }

    public void ResetPins()
    {
        // Reset all pins' positions
        foreach (GameObject pin in pins)
        {
            Pins pinScript = pin.GetComponent<Pins>();
            pinScript.ResetPosition(); // Reset pin via its script
        }
    }
}
