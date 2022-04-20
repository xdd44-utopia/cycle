using UnityEngine;

public class ElephantController : MonoBehaviour
{
	public bool eating = false;
	private Animator anim;
	void Start() {
		eating = false;
		anim = GetComponent<Animator>();
	}
	void Update() {
		anim.SetBool("Eating", eating);
	}
	public void EndEating(){
		eating = false;
	}

}
