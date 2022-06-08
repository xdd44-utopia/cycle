using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintEndTask : MonoBehaviour
{
	public Animator scene;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
	}
	void OnMouseDown()
	{
		scene.SetTrigger("Trigger");
		GameObject.Find("LogController").GetComponent<LogController>().addLog("Paintbook scene finishes");
	}
}
