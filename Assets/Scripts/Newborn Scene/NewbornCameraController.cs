using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbornCameraController : MonoBehaviour
{
	public Camera mainCam;
	public Camera sceneCam;
	public RenderTexture targetTexture;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void startScene() {
		mainCam.enabled = false;
		sceneCam.enabled = true;
		sceneCam.targetTexture = null;
	}

	public void endScene() {
		mainCam.enabled = true;
		sceneCam.enabled = false;
		sceneCam.targetTexture = targetTexture;
	}
}
