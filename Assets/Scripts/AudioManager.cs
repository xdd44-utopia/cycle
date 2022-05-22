using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] clips;
	private AudioSource[] sources;
	private float timer;
	private bool isSwitching;
	private int cur = 0;
	private int nex = 0;
	// Start is called before the first frame update
	void Start()
	{
		sources = new AudioSource[clips.Length];
		for (int i=0;i<clips.Length;i++) {
			sources[i] = gameObject.AddComponent<AudioSource>();
			sources[i].clip = clips[i];
			sources[i].loop = true;
			sources[i].volume = 0;
			sources[i].Pause();
		}
		sources[0].volume = 1;
		sources[0].Play(0);
		cur = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (isSwitching) {
			timer += Time.deltaTime * 0.5f;
			sources[cur].volume = 1 - timer;
			sources[nex].volume = timer;
			if (timer > 1) {
				timer = 1;
				isSwitching = false;
				if (nex != cur) {
					sources[cur].Pause();
				}
				cur = nex;
			}
		}
	}

	public void playClip(int x) {
		if (x < 0 || x >= sources.Length) {
			return;
		}
		nex = x;
		isSwitching = true;
		timer = 0;
		sources[nex].Play(0);
		Debug.Log("Switch to " + x);
	}


}
