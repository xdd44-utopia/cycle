using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PPTPreviewController : MonoBehaviour
{
	public PPTPageController[] pages;
	public int id;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		for (int i=0;i<pages.Length;i++) {
			pages[i].deactivate();
		}
		pages[id].activate();
	}
}
