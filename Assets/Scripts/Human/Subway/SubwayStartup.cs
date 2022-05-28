using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayStartup : MonoBehaviour
{
	public int audioID;
	void Update()
	{
		if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10) {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip(audioID);
			Destroy(this);
		}
	}
}
