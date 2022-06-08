using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeMasterController : MonoBehaviour
{
	private HumanSubSceneSwitch scene;
	private Animator anim;
	private bool started = false;
	void Start() {
		scene = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
		anim = GetComponent<Animator>();
	}
	void Update() {
		if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10 && !started) {
			anim.SetTrigger("Trigger");
			GameObject.Find("LogController").GetComponent<LogController>().addLog("Scene start");
			started = true;
		}
	}
	public void endScene() {
		scene.switchScene(5);
	}
}
