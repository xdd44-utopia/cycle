using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTask : MonoBehaviour
{
	public int targetCount;
	public Animator targetAnim;
	public Animator stickAnim;
	public Collider2D targetCollider;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.childCount == targetCount) {
			targetAnim.SetTrigger("Trigger");
			stickAnim.SetTrigger("Trigger");
			targetCollider.enabled = true;
			Destroy(this);
		}
	}
}
