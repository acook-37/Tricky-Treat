
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{

    enum MiniGameState { idle, active, win, lose }

    [SerializeField]
    MiniGameState curGameState;

   

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
            
                if (PlayerCollect.instanceRef.score >= winScore)
                {

                    curGameState = MiniGameState.win;
                    resultsText.text = "You are a winner";
                    GameOver();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerCollect.instanceRef.ResetPlayerCollect();
        Utility.HideCG(resultsPanelCG);
        curGameState = MiniGameState.active;
        startButton.gameObject.SetActive(false);

       
    }


    private void GameOver()
    {
        Utility.ShowCG(resultsPanelCG);


       

        startButton.gameObject.SetActive(true);

        Text btnText = startButton.GetComponentInChildren<Text>();
        btnText.text = "Play Again";
    }

}
