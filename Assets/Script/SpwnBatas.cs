using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnBatas : MonoBehaviour
{
    public GameObject[] BatasSpwn;
    int MatNo;
    public float delayTimer = 2.0f;
    float timer;
    int b=1;
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
            MatNo=Random.Range(0,b);
            Instantiate(BatasSpwn[MatNo], transform.position, transform.rotation);
            
            timer = delayTimer;
        }
    }
}
