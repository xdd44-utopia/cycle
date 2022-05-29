using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExcelTaskSwitch : MonoBehaviour
{
	public GameObject bar;
	public GameObject line;
	void Start()
	{
		line.SetActive(false);
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		bar.SetActive(!bar.activeSelf);
		line.SetActive(!line.activeSelf);
	}

}
