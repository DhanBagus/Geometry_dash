using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLevelDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Player has entering collision with: OldLevelDestroyerTrigger");
            Debug.Log("Deleting old level!");
            // Destroy (GameObject.FindWithTag("RintanganBOX"));
            DestroyWithTag ("StuffOld");
        }
    }

    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}
