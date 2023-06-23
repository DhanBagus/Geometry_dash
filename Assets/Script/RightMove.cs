using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMove : MonoBehaviour
{
    // public Transform Player;
    // public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    void FixedUpdate(){
        transform.position += Vector3.right * 5 * Time.deltaTime;
        transform.position += Vector3.down * 3 * Time.deltaTime;
        // Vector3 pos = transform.position;
        // pos.x = Player.position.x;
        // transform.position = pos + Offset;
        
    }
    
}
