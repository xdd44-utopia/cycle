using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteWindowController : MonoBehaviour
{
	public NoteTaskController task;
	public int noteID;
	public GameObject note;
	public Transform birdAPos;
	public Animator birdAAnim;
	private Animator anim;
	private SpriteRenderer sprite;
	private bool isMouseOver = false;
	void Start()
	{
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isMouseOver) {
			if (anim != null) {
				anim.enabled = false;
			}
			sprite.color = new Color(1, 1, 1, Mathf.Lerp(sprite.color.a, 1, 0.2f));
		}
		else {
			sprite.color = new Color(1, 1, 1, Mathf.Lerp(sprite.color.a, 0.5f, 0.2f));
			if (anim != null && sprite.color.a - 0.5f < 0.05f) {
				anim.enabled = true;
			} 
		}
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		Instantiate(note, birdAPos);
		birdAAnim.SetTrigger("Sing");
		task.manualTrigger(noteID);
	}

	void OnMouseOver() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		isMouseOver = true;
	}

	void OnMouseExit() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		isMouseOver = false;
	}
}
