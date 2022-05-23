using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
	private HumanSubSceneSwitch controller;
	public int sceneNum;
	void Start() {

	}
	void Update() {
		if (controller == null) {
			controller = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
		}
	}
	private void OnMouseDown()
	{
		controller.switchScene(sceneNum);
	}
}
