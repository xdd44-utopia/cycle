using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPTTask : MonoBehaviour
{
	public Animator scene;
	public PPTPageController[] pages;
	void Update()
	{
		if (isCorrect()) {
			scene.SetTrigger("Trigger");
			GameObject.Find("LogController").GetComponent<LogController>().addLog("PPT task success");
			Destroy(this);
		}
	}
	private bool isCorrect() {
		for (int i=0;i<pages.Length;i++) {
			if (!pages[i].isCorrect()) {
				return false;
			}
		}
		return true;
	}
}
