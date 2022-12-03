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

    private int candyCount = 0;
    public Text candyCollectedLabel;
    public Text endGameMessage;
    public Button restartButton;

    [SerializeField]
    int winScore = 30;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isVictor = false;
      
      //restartButton.gameObject.SetActive(false);
      //  endGameMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkVictory();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("killVolume"))
        {
            gameOver();
        }
    }

    void checkVictory()
    {
        if (Physics2D.OverlapCircle(hitBoxTransform.position, 0.1f, winLayerMask) && !isDead)
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
        //AudioSource.PlayClipAtPoint(candyCollectSound, transform.position);
        endGameMessage.gameObject.SetActive(true);
        endGameMessage.text = "You're free of the curse!";
        //put text on screen or something idk i just work here
        restartButton.gameObject.SetActive(true);
    }

    void gameOver()
    {
        isDead = true;
        Debug.Log("you died!");
        //endGameMessage.gameObject.SetActive(true);
        //endGameMessage.text = "Oh no!";
        //put text on screen or something idk i just work here
        //restartButton.gameObject.SetActive(true);
        restartGame();
    }

}
