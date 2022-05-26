using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintBookOpen : MonoBehaviour
{
	public Animator[] anims;
	public Collider2D[] colliders;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		foreach (Animator anim in anims) {
			anim.SetTrigger("Trigger");
		}
		foreach (Collider2D collider in colliders) {
			collider.enabled = true;
		}
	}
}
