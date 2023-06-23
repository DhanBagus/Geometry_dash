using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScript : MonoBehaviour
{
    public GameObject[] ImgMatrix;
    int MatNo;
    // public float maxPos = 1.0f;
    public float delayTimer = 1.0f;
    float timer;
    int r=1;


    public Transform Player;
    public Vector3 Offset;


    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;

           

           

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        // transform.position += Vector3.right * 8 * Time.deltaTime;
        timer -= Time.deltaTime;
        // transform.position += Vector3.right * 5 * Time.deltaTime;
        if(timer <=0.8 ){
           
            MatNo=Random.Range(0,r);
            Instantiate(ImgMatrix[MatNo], transform.position, transform.rotation);

            
            timer = delayTimer;
        }

        // transform.position += Vector3.down * 3 * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x = Player.position.x;
        transform.position = pos + Offset;
    }
}
