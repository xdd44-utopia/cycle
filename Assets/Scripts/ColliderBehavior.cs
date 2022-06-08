using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderBehavior : MonoBehaviour
{
	public string colliderName;
	public Animator anim;
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
		anim.SetTrigger("Trigger");
		GameObject.Find("LogController").GetComponent<LogController>().addLog("Switched by click on " + colliderName);
	}
}
