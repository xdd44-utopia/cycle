using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUIController : MonoBehaviour
{
	public Animator[] anims;
	public WindowController nextWindow;
	public bool isLastOne;
	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		for (int i=0;i<anims.Length;i++) {
			try {
				anims[i].SetBool("Trigger", true);
			}
			catch (NullReferenceException e) {

			}
			try {
				anims[i].SetTrigger("Trigger");
			}
			catch (NullReferenceException e) {
				
			}
		}
		if (nextWindow != null) {
			nextWindow.activate();
		}
		if (isLastOne) {
			Camera.main.GetComponent<HumanSubSceneSwitch>().switchScene(4);
		}
		Destroy(this);
	}
}
