using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boules : MonoBehaviour
{
    public Vector3 originalPosition; 
    public float resetDelay = 2.0f; 
    private Rigidbody rb;
    private bool isInPlay = false; 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;  
        rb = GetComponent<Rigidbody>();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RemettreBoulePositionInitial"))
        {
            Invoke("ResetPosition", resetDelay);
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition; 
        rb.velocity = Vector3.zero;             
        rb.angularVelocity = Vector3.zero;     
        isInPlay = false;
    }

    public void ResetBallButton()
    {
        Debug.Log("Reset ball button pressed");
        ResetPosition();  
    }

    public void StartPlay()
    {
        isInPlay = true;
    }

    public bool IsInPlay()
    {
        return isInPlay;
    }
}
