using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPTPageController : MonoBehaviour
{
	private List<PPTComponentController> components = new List<PPTComponentController>();
	// Start is called before the first frame update
	void Start()
	{
		for (int i=0;i<transform.childCount;i++) {
			components.Add(transform.GetChild(i).gameObject.GetComponent<PPTComponentController>());
		}
		deactivate();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public bool isCorrect() {
		for (int i=0;i<components.Count;i++) {
			if (!components[i].isCorrect()) {
				return false;
			}
		}
		return true;
	}
	public void activate() {
		for (int i=0;i<components.Count;i++) {
			components[i].activate();
		}
	}

	public void deactivate() {
		for (int i=0;i<components.Count;i++) {
			components[i].deactivate();
		}
	}
}
