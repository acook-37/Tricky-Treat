//Sept 17, 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject goodPrefab, badPrefab;

    public bool activeSpawning = true;

    [SerializeField]
    int pauseTime = 2; //may need to customize for your game

    [SerializeField]
    int numToSpawn = 10; //customize as needed

    [SerializeField]
    float chanceToSpawnBad = 0.10f; //modify as needed

    [SerializeField]
    float xRangeLeft = -8.0f; //customize as needed

    [SerializeField]
    float xRangeRight = 8.0f; //customize as needed

    [SerializeField]
    float yRangeTop = -2.0f; //customize as needed

    [SerializeField]
    float yRangeBottom = -3.5f; //customize as needed

    // Start is called before the first frame update
    void Start()
    {
       activeSpawning = true; //remove this code later
       StartSpawning(); //remove this code later, move to MiniGameManager
    }


    ///Will be exectued in MiniGameManager when startButton clicked
    //MiniGameState is set to active
    public void StartSpawning()
    {
        Debug.Log("Start Spawning called");
        //Loop generates multiple delayed invocations of SpawnPrefab( ) method.
        for (int i = 0; i < numToSpawn; i++)
        {
            Invoke("SpawnPrefab", pauseTime * i * 2);  //Delays between SpawnPrefab( ) exection
        }
    }

    //Executed from the StartSpawning method
    //Many instances of this method will be invoked 
    void SpawnPrefab()
    {
        if (activeSpawning) //won't actually spawn anything unless this is true 
        {
            //Where to spawn based on transform of Spawner gameObject

            Vector3 position = transform.localPosition;
            position.x = Random.Range(xRangeLeft, xRangeRight);
            position.y = Random.Range(yRangeBottom, yRangeTop);

            float rand = Random.value;
            GameObject prefab; //temp variable 
            if (rand < chanceToSpawnBad)
            { //spawn bad prefab
                prefab = Instantiate(badPrefab, position, transform.rotation);
            }
            else  //instantiate good one
            {
                prefab = Instantiate(goodPrefab, position, transform.rotation);
            }
            prefab.transform.SetParent(this.transform); //all spawned objects will be children of the Spawner gameObject
        }
    }//end SpawnPrefab

    //This will be executed from MiniGameManager
    public void StopAllSpawning()
    {
        CancelInvoke("SpawnPrefab");  //cancels all SpawnPrefab( ) methods waiting to be executed
        activeSpawning = false;
        DestroySpawnedObjects();
    }

    //Exectued in StopAllSpawning
    private void DestroySpawnedObjects()
    {
        PickUp[] items = FindObjectsOfType<PickUp>();
        foreach (PickUp item in items)
        {
            Destroy(item.gameObject);
        }
    }

}// end class Spawner
