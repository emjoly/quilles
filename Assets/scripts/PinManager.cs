using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public List<GameObject> pins; 
    private int totalPins;  
    private int knockedDownPins; 

    private void Start()
    {
        pins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pin"));
        totalPins = pins.Count;
    }

    public void CheckPins()
    {
        knockedDownPins = 0;

        foreach (GameObject pin in pins)
        {
            if (!pin.activeSelf)
            {
                knockedDownPins++;
            }
        }

        if (knockedDownPins == totalPins)
        {
            GameController.instance.AllPinsDown();
        }
    }

    public void ResetPins()
    {
        foreach (GameObject pin in pins)
        {
            Pins pinScript = pin.GetComponent<Pins>();
            pinScript.ResetPosition(); 
        }
    }
}
