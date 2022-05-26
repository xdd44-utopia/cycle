using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTaskController : MonoBehaviour
{
	public BirdSubSceneSwitch scene;
	public GameObject[] notes;
	public Transform birdBPos;
	public Animator windowAnim;
	public Animator birdAAnim;
	public Animator birdBAnim;
	private List<List<int>> tasks;
	private enum Status {
		PreDemo,
		Demo,
		Task,
		PostTask
	};
	private Status status = Status.PreDemo;
	private float timer = 0;
	public float[] preIntv;
	public float[] postIntv;
	private float demoIntv = 1f;
	private int curTask = 0;
	private int curNote = 0;

	// Start is called before the first frame update
	void Start()
	{
		tasks = new List<List<int>>() {
			new List<int>(),
			new List<int>(),
			new List<int>()
		};
		tasks[0] = new List<int>() {0};
		tasks[1] = new List<int>() {1, 0, 2};
		tasks[2] = new List<int>() {4, 4, 4, 4, 4, 4};
	}

	// Update is called once per frame
	void Update()
	{
		switch (status) {
			case Status.PreDemo: {
				timer += Time.deltaTime;
				if (timer > preIntv[curTask]) {
					timer = 0;
					preIntv[curTask] = 0.5f;
					status = Status.Demo;
				}
				break;
			}
			case Status.Demo: {
				timer += Time.deltaTime;
				if (timer > demoIntv) {
					switch (curTask) {
						case 0: {
							windowAnim.SetTrigger("Trigger");
							birdBAnim.SetTrigger("Sing");
							Instantiate(notes[tasks[curTask][curNote]], birdBPos);
							break;
						}
						case 1: {
							birdBAnim.SetTrigger("Sing");
							Instantiate(notes[tasks[curTask][curNote]], birdBPos);
							break;
						}
						case 2: {
							birdBAnim.SetTrigger("Sing");
							Instantiate(notes[tasks[curTask][curNote]], birdBPos);
							break;
						}
					}
					timer = 0;
					curNote++;
					if (curNote == tasks[curTask].Count) {
						curNote = 0;
						status = Status.Task;
					}
				}
				break;
			}
			case Status.PostTask: {
				timer += Time.deltaTime;
				if (timer > postIntv[curTask]) {
					curTask++;
					status = Status.PreDemo;
					switch (curTask) {
						case 2: {
							scene.switchScene(1);
							birdAAnim.SetTrigger("Trigger");
							birdBAnim.SetTrigger("Trigger");
							break;
						}
						case 3: {
							scene.switchScene(2);
							birdAAnim.SetTrigger("Trigger");
							birdBAnim.SetTrigger("Trigger");
							Destroy(this.gameObject);
							break;
						}
					}
					timer = 0;
				}
				break;
			}
		}
	}

	public void manualTrigger(int id) {
		if (status != Status.Task) {
			return;
		}
		if (id == tasks[curTask][curNote]) {
			curNote++;
			if (curNote == tasks[curTask].Count) {
				curNote = 0;
				status = Status.PostTask;
				timer = 0;
			}
		}
		else {
			curNote = 0;
			status = Status.PreDemo;
		}
	}
}
