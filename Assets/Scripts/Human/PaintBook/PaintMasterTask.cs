using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMasterTask : MonoBehaviour
{
	public int targetCount;
	public Animator targetAnim;
	public Collider2D collider;
	private int count = 0;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (count == targetCount) {
			targetAnim.SetTrigger("Trigger");
			collider.enabled = true;
			Destroy(this);
		}
	}

	public void addCount() {
		count++;
	}
}
