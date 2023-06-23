using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Player;
    bool riv, right, isG, tm,dU;
    float z;
    public GameObject avatar1, avatar2;
    int PlyObj;
    // Start is called before the first frame update
    void Start()
    {
        riv=false;
        isG=false;
        tm=false;
        right=true;

        Scene currscene = SceneManager.GetActiveScene();
        if (currscene.name == "Lv1"){
            PlyObj=1;
            avatar1.gameObject.SetActive (true);
		    avatar2.gameObject.SetActive (false);
        }
        if (currscene.name == "Lv2"){
            PlyObj=2;
            avatar1.gameObject.SetActive (false);
		    avatar2.gameObject.SetActive (true);

            
        }

        


        
        // rb.velocity = new Vector3(5,rb.velocity.y,8);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if(PlyObj==1){
            //jika ubah gravitasi
            if(riv==true){
                rb.gravityScale = -3;
                // rb.velocity = new Vector3(0,rb.velocity.y,8);
            }else{
                rb.gravityScale = 3;
                // rb.velocity = new Vector3(0,rb.velocity.y,8);
            }

            if(right==true){
                rb.velocity = new Vector3(5,rb.velocity.y,8);
            }else{
                rb.velocity = new Vector3(-5,rb.velocity.y,8);
            }

            //jika mouse click
            if (Input.GetMouseButton(0) && isG==true)
            {
                if(right==true){
                    rb.velocity = new Vector3(rb.velocity.x, 2);
                }else{
                    rb.velocity = new Vector3(rb.velocity.x, -2);
                }
                
                
                if(riv==true){
                    rb.velocity = new Vector3(rb.velocity.y, -10);
                }else{
                    rb.velocity = new Vector3(rb.velocity.y, 10);
                }
                tm=true;
            }

            // Rotasi != jarum jam
            if(tm==true && riv==true && right==true){
                z += Time.deltaTime * 500;
                transform.rotation = Quaternion.Euler(0,0,z);
                if(z>180){
                    z=0;
                    tm=false;
                }
                isG=false;
            }
            if(tm==true && riv==false && right==false){
                z += Time.deltaTime * 500;
                transform.rotation = Quaternion.Euler(0,0,z);
                if(z>180){
                    z=0;
                    tm=false;
                }
                isG=false;
            }

            // rotasi == jarum jam
            if(tm==true && riv==false && right==true){
                z += Time.deltaTime * -500;
                transform.rotation = Quaternion.Euler(0,0,z);
                if(z<-180){
                    z=0;
                    tm=false;
                }
                isG=false;
            }
            if(tm==true && riv==true && right==false){
                z += Time.deltaTime * -500;
                transform.rotation = Quaternion.Euler(0,0,z);
                if(z<-180){
                    z=0;
                    tm=false;
                }
                isG=false;
            }


            if(isG==true&&riv==false){
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            if(isG==true&&riv==true){
                transform.rotation = Quaternion.Euler(180,0,0);
            }
        }else{
            rb.gravityScale = 0;
            // if (dU==true){
                // transform.position += Vector3.right * 5 * Time.deltaTime;
                // transform.position += Vector3.up * 5 * Time.deltaTime;
                // 
            // } else{
                // transform.position += Vector3.right * 5 * Time.deltaTime;
                // transform.position += Vector3.down * 5 * Time.deltaTime;
                // 
            // }

            if (Input.GetMouseButtonDown(0)){
                dU=true;
            }
            if (Input.GetMouseButtonUp(0)){
                dU=false;
            }
        }


        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isG=true;         
        }

        if (collision.gameObject.tag == "diagonal")
        {
            isG=true;         
            transform.rotation = Quaternion.Euler(0,0,-40);  
        }

        if (collision.gameObject.tag == "wall_right")
        {
            right=false;

        }

        if (collision.gameObject.tag == "wall_left")
        {
            right=true;
        }

        if (collision.gameObject.tag == "stuff")
        {
            Scene currscene = SceneManager.GetActiveScene();

            if (currscene.name == "Lv1"){
                SceneManager.LoadScene("Lv1");
            }
            if (currscene.name == "Lv2"){
                SceneManager.LoadScene("Lv2");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "up") 
        {
           riv=true;
        }

        if (col.tag == "down") 
        {
           riv=false;
        }

        if (col.tag == "stuff") 
        {
           riv=false;
        }

        if (col.tag == "levelUp") 
        {
           SceneManager.LoadScene("Lv2");
        }

        if (col.tag == "waveUD") 
        {
            print("Superman");
            if(dU==false){
                dU=true;
            }else{
                dU=false;
            }
            
        }

        

    }
    void OnTriggerStay2D (Collider2D col2){
        if (col2.tag == "RL") 
        {
            // print("Superman");
            // Debug.Log("Mouse 0 ");
            
            
                if (Input.GetKeyDown(KeyCode.Mouse0)){
                    Debug.Log("Mouse 0 ");
                    print("Superman");

                    if(right==true){
                        right=false;
                        
                    }else{
                        right=true;
                    }

                    if(riv==true){
                        rb.velocity = new Vector3(rb.velocity.y, -10);
                    }else{
                        rb.velocity = new Vector3(rb.velocity.y, 10);
                    }
                    tm=true;
                }
            
        }

        
    }

    void FixedUpdate()
    {
        if(PlyObj==2){
            rb.gravityScale = 0;
            if (dU==true && right==true){
                transform.position += Vector3.right * 5 * Time.deltaTime;
                transform.position += Vector3.up * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,0,45);
                
            } 
            if(dU==false && right==true)
            {
                transform.position += Vector3.right * 5 * Time.deltaTime;
                transform.position += Vector3.down * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,0,-45);
                
            }

            if(dU==true && right==false)
            {
                transform.position += Vector3.left * 5 * Time.deltaTime;
                transform.position += Vector3.up * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,0,135);
                
            }
            if(dU==false && right==false)
            {
                transform.position += Vector3.left * 5 * Time.deltaTime;
                transform.position += Vector3.down * 5 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0,0,-135);
                
            }

            // if (Input.GetMouseButtonDown(0)){
                // dU=true;
                // transform.rotation = Quaternion.Euler(0,0,45);
            // }
            // if (Input.GetMouseButtonUp(0)){
                // dU=false;
                // transform.rotation = Quaternion.Euler(0,0,-45);
            // }
        }
    }

}
