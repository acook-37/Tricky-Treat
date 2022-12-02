using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    mushroom, treetrunk                //add as needed
}

[DisallowMultipleComponent] //only one of these scripts allowed on a gameObject
public class PickUp : MonoBehaviour
{


    [SerializeField]  //allows modification in inspector 
    private int value;

    //read-only property
    public int Value
    {
        get { return value; }
    }

    public PickupType type; //what is the PickupType of this object

    private void Start() //this will cause pickups to self-destruct after random range of seconds
    {
        Invoke("DestroyMe", Random.Range(3, 7));
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}