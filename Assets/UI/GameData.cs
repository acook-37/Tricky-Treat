using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : MonoBehaviour
{

    public static GameData instanceRef;

    private int score;
    private int health;


   
    public int Score
    {
        get { return score; } 
                              
    }

    public int Health
    {
        get { return health; } 
    }

    
    void Awake()
    {
        if (instanceRef == null)  
        {
            instanceRef = this; 
            DontDestroyOnLoad(this.gameObject); 
        }
        else  
        {
            DestroyImmediate(this.gameObject);
            Debug.Log("Destroy GameData Imposter");
        }

        
        score = 0;
        health = 100;
       
        

    }  
   
    public void Add(int value)
    {
        score += value;
        Debug.Log("Score updated: " + score); 
    }

    public void TakeDamage(int value)
    {
        health -= value;
        Debug.Log("health updated: " + health); 
        if (health <= 0)
        {
            Debug.Log("Health less than 0"); 
        }
    }
   
    public void BoostHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, 100);
        Debug.Log("boosting health, new health " + health);
    }


    public void ResetGameData()
    {
        score = 0;
        health = 100;
    }


}