using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public List<GameObject> pins; // List to hold all pin GameObjects
    public float resetDelay = 7.0f; // Delay before resetting pins

    private void Start()
    {
        // Find all pin GameObjects in the scene and add them to the list
        pins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pin"));
    }

    public void CheckPins()
    {
        // Check if all pins are down
        foreach (GameObject pin in pins)
        {
            if (pin.activeSelf) // If any pin is active (standing)
            {
                return; // If at least one pin is standing, exit
            }
        }

        // If all pins are down, start reset process
        StartCoroutine(ResetPins());
    }

    private IEnumerator ResetPins()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(resetDelay);

        // Reset all pins' positions
        foreach (GameObject pin in pins)
        {
            pin.SetActive(true); // Set pin active
            pin.transform.position = new Vector3(pin.transform.position.x, 1.0f, pin.transform.position.z); // Reset to original position
            pin.transform.rotation = Quaternion.identity; // Reset rotation if needed
        }
    }
}
