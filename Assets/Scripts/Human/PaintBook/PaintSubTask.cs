using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintSubTask : MonoBehaviour
{
	public bool isFixed;
	public Vector3 target;
	public PaintMasterTask task;
	private bool isReached = false;
	private Animator anim;
	private SpriteRenderer sprite;
	private bool isTriggered = false;
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (sprite.color.a < 0.01f && isTriggered) {
			Destroy(this.gameObject);
		}
		if (target.magnitude != 0 && (transform.localPosition - target).magnitude < 1) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.5f);
			if (!isReached) {
				isReached = true;
				task.addCount();
			}
		}
	}
	protected virtual void OnMouseDrag()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		if (isFixed) {
			return;
		}
		Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
		transform.position = currentWorldPosition;
	}
	protected virtual void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		isTriggered = true;
		if (target.magnitude == 0) {
			anim.SetTrigger("Trigger");
		}
	}

}
