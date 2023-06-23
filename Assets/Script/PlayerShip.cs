using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Rigidbody2D rb;
    public float z;
    public bool tm, isG,riv;
   
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(3,rb.velocity.y,0);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(rb.velocity.x, 2);
            if(riv==true){
                rb.velocity = new Vector3(rb.velocity.y, -2);
                transform.rotation = Quaternion.Euler(180,0,0);
                
            }else{
                rb.velocity = new Vector3(rb.velocity.y, 2);
                transform.rotation = Quaternion.Euler(0,0,35);
            }
            tm=true;
        }

        

        if(riv==true){
            transform.rotation = Quaternion.Euler(180,0,0);
            rb.gravityScale = -0.5f;
            
        }else{
            transform.rotation = Quaternion.Euler(0,0,0);
            rb.gravityScale = 0.5f;
            
        }
    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isG=true;
        }
        if (collision.gameObject.tag == "stuff")
        {
            SceneManager.LoadScene("Ship");
        }
        if(collision.gameObject.tag == "done"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.gameObject.tag == "ShipPortal"){
            SceneManager.LoadScene("Ship");
        }
        
        if(collision.gameObject.tag == "ReversePortal"){
           riv=true;
        }
    }

    
}

//Noice code from internet :)
