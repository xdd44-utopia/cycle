using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordColorSelector : MonoBehaviour
{
	public WordTask task;
	public int id;
	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		task.select(id);
	}
}
