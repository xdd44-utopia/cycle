using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExcelPointController : MonoBehaviour
{
	public bool isBlue;
	public int id;
	public ExcelTask2 task;
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		task.switchPos(isBlue, id);
	}
}
