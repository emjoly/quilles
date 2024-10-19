using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boules : MonoBehaviour
{
    public Vector3 originalPosition;
    public float resetDelay = 2.0f;
    private Rigidbody rb;


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

    // pour reset la position de la balle avec le bouton ou collision
    public void ResetPosition()
    {
        transform.position = originalPosition; // remettre la balle a sa position initiale
        rb.velocity = Vector3.zero; // arreter le mouvement
        rb.angularVelocity = Vector3.zero; // arreter la rotation
    }
}
