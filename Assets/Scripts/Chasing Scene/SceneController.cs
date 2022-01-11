using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	public const float speed = 1f;
	private GameObject elephant;
	// Start is called before the first frame update
	void Start() {
		elephant = GameObject.Find("Elephant");
	}

	// Update is called once per frame
	void Update() {
		if (!elephant.GetComponent<ElephantController>().eating) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
	}
}
