using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tembus : MonoBehaviour
{
    

    public Collider2D portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            portal.isTrigger=true;
        }
    }

    
}
