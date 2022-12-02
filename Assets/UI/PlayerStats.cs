
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerStats : MonoBehaviour
{

    
    [SerializeField]
    Text healthText;

    [SerializeField]
    Text scoreText;
    

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    { 
        UpdateDisplay();
    }

    
    public void UpdateDisplay()
    {
       
        scoreText.text = "Score:  " + GameData.instanceRef.Score;
    }
} 