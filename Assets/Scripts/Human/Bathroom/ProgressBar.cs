using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
	public Transform mask;
	private float empty;
	private float full;
	void Start()
	{
		empty = mask.localPosition.x;
		full = 0;
	}

	public void updateBar(float x) {
		mask.localPosition = new Vector3(Mathf.Lerp(empty, full, x), 0, 0);
	}
}
