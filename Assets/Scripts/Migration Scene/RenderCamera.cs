using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamera : MonoBehaviour
{
	private float speed = 1f;
	public float recurPos;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
		if (transform.position.x > recurPos) {
			transform.position -= new Vector3(recurPos, 0, 0);
		}
	}
}
