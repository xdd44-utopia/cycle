using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WechatTrigger : MonoBehaviour
{
	public Animator scene;
	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		scene.SetTrigger("Trigger");
		GameObject.Find("LogController").GetComponent<LogController>().addLog("Wechat operation");
		Destroy(this);
	}
}
