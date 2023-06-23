using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MatrixBehaviour : MonoBehaviour
{
    Animator myAnimator;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.Play("MatrixAnim2",0,Random.value);
    }
    
}
