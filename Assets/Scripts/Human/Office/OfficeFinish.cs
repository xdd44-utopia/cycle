using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeFinish : MonoBehaviour
{
	private HumanSubSceneSwitch scene;
	void Start() {
		scene = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
	}
	public void endScene() {
		scene.switchScene(6);
	}
}
