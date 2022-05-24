using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintEndTask : MonoBehaviour
{
	private HumanSubSceneSwitch controller;
	public int sceneNum;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (controller == null) {
			controller = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
		}
	}
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		controller.switchScene(0);
	}
}
