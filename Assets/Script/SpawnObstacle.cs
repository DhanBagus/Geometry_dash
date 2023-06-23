using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject spwnTop, spwnBtm;
    public GameObject[] BoxSpwn;
    public GameObject[] ShipSpwn;
    public GameObject[] BallSpwn;
    public GameObject[] PanahSpwn;
    public GameObject avatar1, avatar2, avatar3,avatar4;
    GameObject StuffBox;
    GameObject StuffShip;
    GameObject StuffBall;
    GameObject StuffNew;
    int MatNo;
    // public float maxPos = 1.0f;
    public float delayTimer = 2.0f;
    float timer;
    public int b=8;
    public int s=7;
    public int bl=5;
    public int w=3;
    // Start is called before the first frame update
    void Start()
    {
         timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += Vector3.right * 5 * Time.deltaTime;
        if(timer < 0 ){

            if(avatar1.gameObject.activeSelf){
                MatNo=Random.Range(0,b);
                StuffNew = Instantiate(BoxSpwn[MatNo], transform.position, transform.rotation);
                StuffNew.tag = "StuffNew";
                Debug.Log("Successfully changed tag from stuff to StuffNew!");
                print("Matno =" + MatNo);
            }
            if(avatar2.gameObject.activeSelf){
                MatNo=Random.Range(0,s);
                StuffNew = Instantiate(ShipSpwn[MatNo], transform.position, transform.rotation);
                StuffNew.tag = "StuffNew";
                Debug.Log("Successfully changed tag from stuff to StuffNew!");
            }
            if(avatar3.gameObject.activeSelf){
                if(MatNo==4){
                    spwnTop.gameObject.SetActive (false);
                    spwnBtm.gameObject.SetActive (false);
                }
                MatNo=Random.Range(0,bl);
                StuffNew = Instantiate(BallSpwn[MatNo], transform.position, transform.rotation);
                StuffNew.tag = "StuffNew";
                Debug.Log("Successfully changed tag from stuff to StuffNew!");
            }
            if(avatar4.gameObject.activeSelf){
                
                MatNo=Random.Range(0,w);
                StuffNew = Instantiate(PanahSpwn[MatNo], transform.position, transform.rotation);
                StuffNew.tag = "StuffNew";
                Debug.Log("Successfully changed tag from stuff to StuffNew!");
            }
            
           
            // MatNo=Random.Range(0,b);
            // Instantiate(BoxSpwn[MatNo], transform.position, transform.rotation);
           
            
            
            timer = delayTimer;
        }
    }
}
