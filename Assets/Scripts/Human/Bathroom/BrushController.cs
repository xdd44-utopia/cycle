using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrushController : MonoBehaviour
{
	public Animator humanAnim;
	private Vector3 preMousepos;
	private float stopTime = 0.125f;
	private float timer = 0;
	void Update() {
		if (timer > stopTime) {
			humanAnim.SetBool("isBrush", false);
		}
		else {
			timer += Time.deltaTime;
		}
	}
	private void OnMouseDrag() {
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if ((Input.mousePosition - preMousepos).magnitude > 5) {
			humanAnim.SetBool("isBrush", true);
			timer = 0;
		}
		preMousepos = Input.mousePosition;
	}
}
