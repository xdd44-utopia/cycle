using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {
	void Update()
	{
		Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
		transform.position = new Vector3(currentWorldPosition.x, currentWorldPosition.y, 0);
	}
}
