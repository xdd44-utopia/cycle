using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //if(Input.GetMouseButtonDown(0)&&IsPointerOverGameObject()){
      //  anim.SetBool("Eating")=true;
      //} 
    }
    void Eating(){
        anim.SetBool("Eating",true);
    }
    void EndEating(){
        anim.SetBool("Eating",false);
    }
}
