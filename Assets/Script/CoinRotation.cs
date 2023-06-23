using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public Collider2D coinGift;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y += 5;
        transform.rotation = Quaternion.Euler(0,y,0);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            coinGift.isTrigger=true;
            Destroy(gameObject);
        }
    }
}
