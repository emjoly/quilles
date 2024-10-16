using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public Vector3 originalPosition; // Original position of the pin
    public float resetDelay = 7.0f; // Time before the pin resets

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Save the original position
    }

    // Update is called once per frame
    void Update()
    {
        // You can add additional functionality here if needed
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the pin was hit with significant force
        if (collision.relativeVelocity.magnitude > 0.5f) // Adjust based on your needs
        {
            Invoke("ResetPosition", resetDelay); // Call the reset function after the specified delay
        }
    }

    private void ResetPosition()
    {
        transform.position = originalPosition; // Reset the position
        transform.rotation = Quaternion.identity; // Reset rotation if needed
    }
}
