using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBookFinish : MonoBehaviour
{
	private Animator anim;
	private HumanSubSceneSwitch scene;
	void Start() {
		anim = GetComponent<Animator>();
		if (!Settings.startFromScratch) {
			anim.Play("OpenDialog", 0, 1);
		}
		scene = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
	}
	public void endScene() {
		scene.switchSceneWithoutFade(1);
	}
}
