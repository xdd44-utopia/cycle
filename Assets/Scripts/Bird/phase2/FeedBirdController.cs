using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedBirdController : MonoBehaviour
{
	public FoodCollector foodCollector;
	private bool isfeeded;
	// Start is called before the first frame update
	void Start()
	{
		isfeeded = false;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (!isfeeded) {
			foodCollector.feed();
			isfeeded = true;
		}
	}
}
