using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelLineController : MonoBehaviour
{
	public Transform[] points;
	private LineRenderer line;
	void Start()
	{
		line = GetComponent<LineRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		for (int i=0;i<points.Length;i++) {
			line.SetPosition(i, points[i].localPosition);
		}
	}
}
