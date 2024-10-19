using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Platform;
public class Boules : MonoBehaviour
{
    public Vector3 originalPosition;
    public float resetDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Additional VR-specific functionality can be added here if needed
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RemettreBoulePositionInitial"))
        {
            Invoke("ResetPosition", resetDelay);
            GameController.instance.BallThrown();
        }
    }

    private void ResetPosition()
    {
        transform.position = originalPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
