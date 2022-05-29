using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] clips;
	public bool[] isLoop;
	public bool playOnStartUp;
	private AudioSource[] sources;
	private float timer;
	private bool isSwitching = false;
	private int cur = 0;
	private int nex = 0;
	private float prevVolume = 0;
	// Start is called before the first frame update
	void Start()
	{
		sources = new AudioSource[clips.Length];
		for (int i=0;i<clips.Length;i++) {
			sources[i] = gameObject.AddComponent<AudioSource>();
			sources[i].clip = clips[i];
			sources[i].loop = isLoop[i];
			sources[i].volume = 0;
			sources[i].Pause();
		}
		sources[0].volume = 1;
		if (playOnStartUp) {
			sources[0].Play(0);
		}
		else {
			sources[0].Pause();
		}
		cur = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (isSwitching) {
			timer += Time.deltaTime * 0.5f;
			sources[cur].volume = (1 - timer) * Settings.volume;
			// Debug.Log(cur + " " + nex + " " + sources[cur].volume);
			if (nex >= 0) {
				sources[nex].volume = timer * Settings.volume;
			}
			if (timer > 1) {
				timer = 1;
				isSwitching = false;
				if (nex != cur) {
					sources[cur].Pause();
				}
				cur = nex >= 0 ? nex : 0;
			}
		}
		else if (prevVolume != Settings.volume) {
			for (int i=0;i<sources.Length;i++) {
				if (sources[i].volume > 0) {
					sources[i].volume = Settings.volume;
				}
			}
			prevVolume = Settings.volume;
		}
	}

	public void playClip(int x) {
		if (x >= sources.Length) {
			return;
		}
		if (x >= 0) {
			sources[x].Play(0);
			if (isLoop[x]) {
				if (isSwitching) {
					if (nex != cur) {
						sources[cur].Pause();
					}
					cur = nex >= 0 ? nex : 0;
				}
				nex = x;
				isSwitching = true;
				timer = 0;
				sources[x].volume = 0;
			}
			else {
				sources[x].volume = Settings.volume;
			}
		}
		else if (isLoop[cur]) {
			sources[cur].Pause();
			sources[cur].volume = 0;
		}
	}

	public void pauseClip(int x) {
		sources[x].Pause();
		sources[x].volume = 0;
	}

}
