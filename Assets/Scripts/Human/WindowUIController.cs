using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUIController : MonoBehaviour
{
	public Animator[] anims;
	public WindowController nextWindow;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseDown() {
		for (int i=0;i<anims.Length;i++) {
			anims[i].SetBool("Trigger", true);
		}
		if (nextWindow != null) {
			nextWindow.activate();
		}
	}
}
