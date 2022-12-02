
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MiniGameManager : MonoBehaviour
{

    enum MiniGameState { idle, active, win, lose }

    [SerializeField]
    MiniGameState curGameState;

    [SerializeField]
    Spawner spawner;

    [SerializeField]
    Button startButton; 

    [SerializeField]
    Text resultsText;   

    [SerializeField]
    CanvasGroup resultsPanelCG; 

    [SerializeField]
    int winScore = 30;


    
    void Start()
    {
        curGameState = MiniGameState.idle;
        Utility.ShowCG(resultsPanelCG); 
        resultsText.text = "Score " + winScore + " To Win";
        startButton.onClick.AddListener(ReStartGame);
    }

    
    void Update()
    {
        if (curGameState == MiniGameState.active)
        {
            if (GameData.instanceRef.Health > 0)
            {
                if (GameData.instanceRef.Score >= winScore)
                {
                    
                    curGameState = MiniGameState.win;
                    resultsText.text = "You are a winner";
                    GameOver();
                }
            }
            else  
            {
                curGameState = MiniGameState.lose;
                resultsText.text = "You lost, so sorry, try again";
                GameOver();
            }

        } 
    } 

    
    public void ReStartGame()  
    {
        GameData.instanceRef.ResetGameData();  
        Utility.HideCG(resultsPanelCG); 
        curGameState = MiniGameState.active;
        startButton.gameObject.SetActive(false);
       
        spawner.activeSpawning = true;
        spawner.StartSpawning();
    }

    
    private void GameOver()
    {
        Utility.ShowCG(resultsPanelCG); 

        
        spawner.StopAllSpawning();

        startButton.gameObject.SetActive(true);
        
        Text btnText = startButton.GetComponentInChildren<Text>();
        btnText.text = "Play Again";
    }

}
