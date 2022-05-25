using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PPTComponentController : MonoBehaviour
{
	public int ans;
	private int cur;
	private bool isActivated = false;
	private Collider2D collider;
	private List<SpriteRenderer> sprites = new List<SpriteRenderer>();
	// Start is called before the first frame update
	void Start()
	{
		collider = GetComponent<Collider2D>();
		for (int i=0;i<transform.childCount;i++) {
			sprites.Add(transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
		}
	}

	// Update is called once per frame
	void Update()
	{
		for (int i=0;i<sprites.Count;i++) {
			sprites[i].enabled = false;
		}
		if (isActivated) {
			sprites[cur].enabled = true;
			collider.enabled = true;
		}
		else {
			collider.enabled = false;
		}
	}
	public bool isCorrect() {
		return cur == ans;
	}
	public void activate() {
		isActivated = true;
	}
	public void deactivate() {
		isActivated = false;
	}
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		cur = (cur + 1) % sprites.Count;
	}
}
