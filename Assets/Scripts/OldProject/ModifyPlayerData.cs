using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModifyPlayerData : MonoBehaviour
{
    [SerializeField]
    Text updateText;
    string displayText;
    string newLine = System.Environment.NewLine;  

    private void Start()
    {
        
        displayText = "Journal Updates: ";
        UpdateDisplay();
    }

    public void IncreaseScore(int value)
    {
        GameData.instanceRef.Add(value);
        displayText = "Increase" + newLine + "Memory: " + value;
        UpdateDisplay();
    }

   
    public void IncreaseHealth(int value)
    {
        GameData.instanceRef.BoostHealth(value);
        displayText = "Boost Grounding " + value;
        UpdateDisplay();
    }

    public void DecreaseHealth(int value)
    {
        GameData.instanceRef.TakeDamage(value);
        displayText = "Decrease" + newLine + "Grounding: " + value;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (updateText != null)
        {
            updateText.text = displayText;
        }

    }

}