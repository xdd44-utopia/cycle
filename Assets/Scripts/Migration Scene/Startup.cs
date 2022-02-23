using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
	public Animator[] anims;
	public GameObject firstArc;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void animFinished() {
		foreach (Animator anim in anims) {
			anim.SetBool("Trigger", true);
		}
		firstArc.GetComponent<ArcController>().switchStates();
		Destroy(this.gameObject);
	}
}
