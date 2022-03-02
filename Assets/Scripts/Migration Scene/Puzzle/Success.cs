using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
	public GameObject[] circles;
	public GameObject controller;
	public GameObject prevArc;
	public GameObject nextArc;
	private bool hasSucceeded = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!Input.GetMouseButton(0) && checkSuccess() && !hasSucceeded)
        {
			this.GetComponent<Animator>().SetBool("Trigger", true);
		}
	}
    
    private bool checkSuccess()
	{
		bool Success = true;
		foreach (GameObject g in circles)
		{
			float temp = g.transform.rotation.eulerAngles.z;
			if (temp < -180)
			{
				temp += 360;
			}
			if (temp > 180)
			{
				temp -= 360;
			}
			if (temp>5.0f|| temp <-5.0f)
            {
				//Debug.Log(g.transform.rotation.eulerAngles.z);
				Success = false;
				break;
            }
		}
		return Success;
	}

	public void succeeded() {
		foreach (GameObject g in circles)
		{
			g.GetComponent<CircleCollider2D>().enabled = false;
		}
		this.GetComponent<Animator>().SetBool("Trigger", false);
		controller.GetComponent<PuzzleController>().switchStates();
		prevArc.GetComponent<ArcController>().switchStates();
		nextArc.GetComponent<ArcController>().switchStates();
		hasSucceeded = true;
	}
}
