using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		controller.switchScene(sceneNum);
	}
}
