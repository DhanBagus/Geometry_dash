using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
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
            Debug.Log("Player has entering ChangeTagTrigger");
            TagChanger("StuffNew");
            // GameObject[] change;
            // change = GameObject.FindGameObjectsWithTag("RintanganBOX");
            // change.tag = "RintanganBOX_OLD";
            Debug.Log("Successfully changed tag to: StuffOld!");
        }
    }

    void TagChanger (string theTag)
    {
        GameObject[] changetagObject;
        changetagObject = GameObject.FindGameObjectsWithTag(theTag);
        foreach (GameObject oneObject in changetagObject)
            oneObject.tag = "StuffOld";
    }
}
