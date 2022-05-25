using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExcelBarController : MonoBehaviour
{
	public bool isUpper;
	public int id;
	public ExcelTask1 task;
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		task.switchSprite(isUpper, id);
	}
}
