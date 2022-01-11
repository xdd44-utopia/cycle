using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteTree : MonoBehaviour
{
	private GameObject elephant;
	// Start is called before the first frame update
	void Start()
	{
		elephant = GameObject.Find("Elephant");
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnMouseDown() {
		if (Mathf.Abs(elephant.transform.position.x + 5f - transform.position.x) < 1.5f) {
			elephant.GetComponent<ElephantController>().eating = true;
		}
	}
}
