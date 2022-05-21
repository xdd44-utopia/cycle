using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScreen : MonoBehaviour
{
	public RectTransform circle;
	public Button[] buttons;
	private int cur = 0;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		circle.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(circle.localRotation.eulerAngles.z, cur * 36, 0.025f));
		for (int i=0;i<buttons.Length;i++) {
			buttons[i].interactable = true;
		}
		buttons[cur].interactable = false;
	}

	public void switchTo(int x) {
		cur = x;
	}
}
