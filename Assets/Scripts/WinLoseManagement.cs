using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseManagement : MonoBehaviour
{
    public Transform hitBoxTransform; //get player hitbox
    public LayerMask hazardsLayerMask;
    public LayerMask winLayerMask;

    private bool isDead;
    private bool isVictor;
    public bool hasControl;

    private int candyCount = 0;
    public Text candyCollectedLabel;
    public Text resultsText;
    public Button restartButton;

    public GameObject openGoal;
    public GameObject closeGoal;
    public GameObject resultsPanel;

    public PlayerCollect pCollect;

    [SerializeField]
    int winScore = 30;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isVictor = false;
        hasControl = true;

        openGoal.SetActive(false);
        resultsText.text = "Score " + winScore + " to win and free yourself of the curse.";
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(restartGame);
        resultsPanel.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(checkComplete())
        {
            openGoal.SetActive(true);
            closeGoal.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("killVolume"))
        {
            gameOver();
        }

        if (other.gameObject.CompareTag("winVolume"))
        {
            winGame();
        }
    }

    

    void CollectCandy(BoxCollider collision)
    {
        candyCount++;
        candyCollectedLabel.text = "POINTS: " + candyCount.ToString();
        //AudioSource.PlayClipAtPoint(candyCollectSound, transform.position);
        Destroy(collision.gameObject);
        Debug.Log(candyCount);
    }

    // check if the player gets collectible
    private void OnCollisionEnter(Collision candy) //currently collider 2D need to fix
    {
        if (candy.gameObject.CompareTag("candy"))
        {
            CollectCandy(candy);
        }
    }

    void CollectCandy(Collision candy)
    {
        candyCount++;
        candyCollectedLabel.text = "POINTS: " + candyCount.ToString();
        //AudioSource.PlayClipAtPoint(candyCollectSound, transform.position);
        Destroy(candy.gameObject);
        Debug.Log(candyCount);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads current scene
        Debug.Log("restart pressed");
       

    }

    //win and lose
    void winGame()
    {
        isVictor = true;
        Debug.Log("you win!");
        hasControl = false;
        //AudioSource.PlayClipAtPoint(candyCollectSound, transform.position);
        resultsPanel.gameObject.SetActive(true);
        resultsText.text = "You're free of the curse!";
        //put text on screen or something idk i just work here
        restartButton.gameObject.SetActive(false);
    }

    void gameOver()
    {
        isDead = true;
        Debug.Log("you died!");
        resultsPanel.gameObject.SetActive(true);
        resultsText.text = "Oh no!";
        //put text on screen or something idk i just work here
        restartButton.gameObject.SetActive(false);
        restartGame();
    }

    bool checkComplete()
    {
        if (pCollect.score >= winScore)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
