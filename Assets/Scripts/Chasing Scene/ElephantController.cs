using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantController : MonoBehaviour
{
	public Animator anim;
	public bool eating = false;
	void Start() {
		eating = false;
	}
	void Update() {
		anim.SetBool("Eating", eating);
	}
	public void EndEating(){
		eating = false;
	}

}
