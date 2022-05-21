using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
	private SubSceneSwitch controller;
	public int sceneNum;
	void Start() {

	}
	void Update() {
		if (controller == null) {
			controller = Camera.main.gameObject.GetComponent<SubSceneSwitch>();
		}
	}
	private void OnMouseDown()
	{
		controller.switchScene(sceneNum);
	}
}
