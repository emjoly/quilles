using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class EnregistrementNom : MonoBehaviour
{

    public TextMeshProUGUI zoneNom;
    public InputField zoneEntreeNom;

    public GameObject clavier;
    public GameObject canvasNom;

    bool canvasInputActif;


    void Start(){

        clavier.SetActive(false);

    }


    void Update()
    {

       if (zoneEntreeNom.isFocused) clavier.SetActive(true);
       if (!zoneEntreeNom.isFocused) clavier.SetActive(false);
    
    }

    public void AfficherCanvas()
    {
       canvasInputActif = !canvasInputActif;
       canvasNom.SetActive(canvasInputActif);
        
       // canvasNom.SetActive(true);
    }

    public void AfficherNom()
    {
        zoneNom.text = zoneEntreeNom.text;
      
        canvasNom.SetActive(false);
        clavier.SetActive(false);
    }


}
    