using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float z;
    public bool tm, isG,riv,dU;
    public GameObject avatar1, avatar2, avatar3,avatar4, bg1,cam1, cam2;
    int PlayObj=1;
    int Skor=0;
    public Text SkorText, GameScore;
    bool fly;
    float ship=0.0f;
    // private AudioSource source;


    // public Transform GroundCheckTransform;
    // public float GroundCheckRadius;
    // public LayerMask GroundMask;
    
   
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // text = GetComponent<Text>();
        avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
        avatar3.gameObject.SetActive (false);
        avatar4.gameObject.SetActive (false);

        bg1.gameObject.SetActive(true);
        
        // canvas1.gameObject.SetActive(true);
        // canvas2.gameObject.SetActive(false);

        // cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);

        // source = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        SkorText.text="Scor : "+Skor;
        GameScore.text=""+Skor;
        print(Skor);
        

        if(PlayObj==1){
            //jika ubah gravitasi
            if(riv==true){
                rb.gravityScale = -2;
                rb.velocity = new Vector3(5,rb.velocity.y,8);
            }else{
                rb.gravityScale = 2;
                rb.velocity = new Vector3(5,rb.velocity.y,8);
            }

            //jika mouse click
            if (Input.GetMouseButtonDown(0) && isG==true)
            {
                
                rb.velocity = new Vector3(rb.velocity.x, 5);
                if(riv==true){
                    rb.velocity = new Vector3(rb.velocity.y, -8);
                }else{
                    rb.velocity = new Vector3(rb.velocity.y, 8);
                }
                tm=true;

                // source.Play();
            }


            if(tm==true && riv==true){
                z += Time.deltaTime * 500;
                transform.rotation = Quaternion.Euler(0,0,z);
                if(z>180){
                    z=0;
                    tm=false;
                }
                isG=false;
            }
            if(tm==true && riv==false){
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
            // end

        }

        if(PlayObj==2){
            tm=false;
            if(riv==true){
                
                rb.gravityScale = -1;
                transform.rotation = Quaternion.Euler(180,0,0);
                rb.velocity = new Vector3(5,rb.velocity.y,-3);
               
                
            }else{
                transform.rotation = Quaternion.Euler(0,0,0);
                rb.gravityScale = 1;
                rb.velocity = new Vector3(5,rb.velocity.y,3);
                
            }


            if (Input.GetMouseButtonDown(0))
            {
                fly=true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                fly=false;
            }
            

            if (fly==true)
            {
                // 
                if(riv==true){
                    ship+=2;
                    rb.velocity = new Vector3(rb.velocity.x, 5);
                    rb.velocity = new Vector3(rb.velocity.y, -3);
                    transform.rotation = Quaternion.Euler(180,0,ship);
                    if(ship>25){
                        ship=25;
                    }
                    
                }
                if(riv==false){
                    ship+=2;
                    rb.velocity = new Vector3(rb.velocity.x, 5);
                    rb.velocity = new Vector3(rb.velocity.y, 3);
                    transform.rotation = Quaternion.Euler(0,0,ship);
                    if(ship>25){
                        ship=25;
                    }
                }
               
            }

            else{
                if(riv==true){
                    ship-=0.7f;
                    transform.rotation = Quaternion.Euler(180,0,ship);
                    if(ship<-25){
                        ship=-25;
                    }

                }
                else{
                    ship-=0.7f;
                   
                    transform.rotation = Quaternion.Euler(0,0,ship);
                    if(ship<-25){
                        ship=-25;
                    }
                }
            }

            

            
        }

        // if(isG==true&&riv==false){
        //     transform.rotation = Quaternion.Euler(0,0,0);
        // }
        // if(isG==true&&riv==true){
        //     transform.rotation = Quaternion.Euler(180,0,0);
        // }


        if(PlayObj==3){
           tm=false;
            rb.velocity = new Vector3(5,rb.velocity.y,8);
            transform.rotation = Quaternion.Euler(0,0,0);
            
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(rb.velocity.x, 5);
                if(rb.gravityScale > 0){
                    rb.gravityScale = -3;
                }else{
                    rb.gravityScale = 3;
                }
            }
            if(rb.gravityScale > 1){
                z += Time.deltaTime * -500;
                transform.rotation = Quaternion.Euler(0,0,z);
            }
            if(rb.gravityScale < 1){
                z -= Time.deltaTime * 500;
                transform.rotation = Quaternion.Euler(0,180,z);
            }

        }

        if(PlayObj==4){
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
                transform.rotation = Quaternion.Euler(0,0,45);
            }
            if (Input.GetMouseButtonUp(0)){
                dU=false;
                transform.rotation = Quaternion.Euler(0,0,-45);
            }
        }
    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isG=true;
            
            if(Input.GetMouseButtonDown(0) && PlayObj==1)
            {
                
                tm=true;
            }
            if(PlayObj==4){
                // transform.rotation = Quaternion.Euler(0,0,0);
            }
            
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
            // if(ManUI.LevelChange.levelC==1){
            //     SceneManager.LoadScene("Lv1");
            // }
            // if(ManUI.LevelChange.levelC==1){
            //     SceneManager.LoadScene("Lv1");
            // }
        }
        // if (collision.gameObject.tag == "StuffNew")
        // {
            // Scene currscene = SceneManager.GetActiveScene();
        // 
            // if (currscene.name == "Lv1"){
                // SceneManager.LoadScene("Lv1");
            // }
            // if (currscene.name == "Lv2"){
                // SceneManager.LoadScene("Lv2");
            // }
            // if(ManUI.LevelChange.levelC==1){
            //     SceneManager.LoadScene("Lv1");
            // }
            // if(ManUI.LevelChange.levelC==1){
            //     SceneManager.LoadScene("Lv1");
            // }
        // }
        if(collision.gameObject.tag == "done"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.gameObject.tag == "BasicPortal"){
            PlayObj=1;
            avatar1.gameObject.SetActive (true);
			avatar2.gameObject.SetActive (false);
            avatar3.gameObject.SetActive (false);
            avatar4.gameObject.SetActive (false);
            // transform.rotation = Quaternion.Euler(0,0,ship);
        }
        if(collision.gameObject.tag == "ShipPortal"){
            PlayObj=2;
            avatar1.gameObject.SetActive (false);
			avatar2.gameObject.SetActive (true);
            avatar3.gameObject.SetActive (false);
            avatar4.gameObject.SetActive (false);
            transform.rotation = Quaternion.Euler(0,0,ship);
        }
        if(collision.gameObject.tag == "BallPortal"){
            PlayObj=3;
            avatar1.gameObject.SetActive (false);
			avatar2.gameObject.SetActive (false);
            avatar3.gameObject.SetActive (true);
            avatar4.gameObject.SetActive (false);
            // transform.rotation = Quaternion.Euler(0,0,ship);
            rb.gravityScale = 3;
           
        }
        if(collision.gameObject.tag == "WavePortal"){
            PlayObj=4;
            avatar1.gameObject.SetActive (false);
			avatar2.gameObject.SetActive (false);
            avatar3.gameObject.SetActive (false);
            avatar4.gameObject.SetActive (true);
            dU=false;
            transform.rotation = Quaternion.Euler(0,0,0);
            rb.gravityScale = 0;
        }
        
        if(collision.gameObject.tag == "ReversePortal"){
            rb.gravityScale = -3;
            riv=true;
        }
        if(collision.gameObject.tag == "NormalPortal"){
           riv=false;
        }
        if(collision.gameObject.tag == "Coin"){
           Skor+=1;
        }
        if(collision.gameObject.tag == "FinishLine"){
        //    canvas1.gameObject.SetActive(false);
        //    canvas2.gameObject.SetActive(true);

           cam1.gameObject.SetActive(false);
           cam2.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if(PlayObj==4){
            rb.gravityScale = 0;
            if (dU==true){
                transform.position += Vector3.right * 5 * Time.deltaTime;
                transform.position += Vector3.up * 5 * Time.deltaTime;
                
            } else{
                transform.position += Vector3.right * 5 * Time.deltaTime;
                transform.position += Vector3.down * 5 * Time.deltaTime;
                
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

    // bool OnGround()
    // {
    //     return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
    // }

    
}
