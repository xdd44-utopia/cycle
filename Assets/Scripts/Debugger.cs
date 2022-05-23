using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
	public BirdSubSceneSwitch scene;
	private int nex = 1;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseDown() {
		scene.switchScene(nex);
		nex++;
	}
}
