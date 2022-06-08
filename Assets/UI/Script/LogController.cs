using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogController : MonoBehaviour
{
	public GameObject logObject;
	public Text logText;
	private Queue logs = new Queue();
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("t")) {
			logObject.SetActive(!logObject.activeSelf);
		}
	}

	public void addLog(string message) {
		logs.Enqueue(message);
		if (logs.Count > 5) {
			logs.Dequeue();
		}
		string retText = "";
		object[] logArray = logs.ToArray();
		for (int i=0;i<logs.Count;i++) {
			retText += logArray[i] + "\n";
		}
		logText.text = retText;
	}
}
