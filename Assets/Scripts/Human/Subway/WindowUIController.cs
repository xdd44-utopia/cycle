using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUIController : MonoBehaviour
{
	public Animator[] anims;
	public WindowController[] nextWindows;
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
		if (nextWindows.Length > 0) {
			for (int i=0;i<nextWindows.Length;i++) {
				nextWindows[i].activate();
			}
		}
		if (isLastOne) {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip(-1);
			Camera.main.GetComponent<HumanSubSceneSwitch>().switchScene(4);
		}
		Destroy(this);
	}
}
