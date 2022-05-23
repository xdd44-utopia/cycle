using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		controller.switchScene(0);
	}
}
