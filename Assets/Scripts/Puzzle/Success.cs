using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
	public GameObject[] circles;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!Input.GetMouseButton(0)&& checkSuccess())
        {
			Debug.Log("Success");
			Destroy(this.gameObject);
		}
	}
    
    public bool checkSuccess()
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
}
