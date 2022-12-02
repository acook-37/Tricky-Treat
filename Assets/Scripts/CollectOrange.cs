using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CollectOrange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.name =="PF_pumpkin")
        {
            other.GetComponent<PlayerCollect>().points++;
            Destroy(gameObject); 
        }
    }
}
