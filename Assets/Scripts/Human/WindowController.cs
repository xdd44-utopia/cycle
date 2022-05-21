using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
	public float automateTime;
	private float timer = 0;
	private Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (automateTime >= 0) {
			timer += Time.deltaTime;
			if (timer > automateTime) {
				activate();
				automateTime = -1;
			}
		}
	}

	public void activate() {
		anim.SetBool("Trigger", true);
	}
}
