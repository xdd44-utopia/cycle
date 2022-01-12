using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	public static float speed = 1f;
	public static bool switchScene;
	private bool switching = false;
	private int sceneID;
	private GameObject elephant;
	// Start is called before the first frame update
	void Start() {
		elephant = GameObject.Find("Elephant");
		speed = 1f;
		sceneID = 0;
		switchScene = false;
	}

	// Update is called once per frame
	void Update() {
		if (switchScene) {
			sceneID++;
			switchScene = false;
			switching = true;
		}
		switch (sceneID) {
			case 0:
				scene1();
				break;
			case 1:
				if (switching) {
					scene1to2();
				}
				else {
					scene2();
				}
				break;
		}
	}

	private void scene1() {
		if (!elephant.GetComponent<ElephantController>().eating) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
	}

	private void scene1to2() {

	}

	private void scene2() {

	}
}
