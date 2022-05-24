using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BathroomTaskController : MonoBehaviour
{
	public int MinAngle;
	public int MaxAngle;
	public float threshold;
	public float goal;
	private Transform mask;
	private Vector3 maskCenterPos;
	private float acc;
	private Vector3 preMousepos;
	private bool isMoving;
	private float timer = 0;
	// Start is called before the first frame update
	void Start()
	{
		isMoving = false;
		mask = this.gameObject.transform.GetChild(1);
		maskCenterPos = mask.localPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (isMoving) {
			acc += Time.deltaTime;
			timer += Time.deltaTime;
			if (timer > 0.1f) {
				isMoving = false;
			}
		}
		if (acc > goal) {
			Debug.Log("Success");
		}
		else {
			mask.transform.localScale = new Vector3(acc / goal, 1, 1);
			mask.transform.localPosition = new Vector3(maskCenterPos.x - 1.67f * (1 - acc / goal), maskCenterPos.y, maskCenterPos.z);
		}
	}
	protected virtual void OnMouseDrag()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		Vector3 deltapos = Vector3.zero;
		if ((Input.mousePosition - preMousepos).magnitude > 10) {
			deltapos = Input.mousePosition - preMousepos;
			preMousepos = Input.mousePosition;
		}
		if (deltapos.y != 0 && deltapos.x != 0)
		{
			float angle = Mathf.Atan(Mathf.Abs(deltapos.y) / Mathf.Abs(deltapos.x));
			angle = angle * 180 / Mathf.PI;
			if (deltapos.magnitude > threshold && angle > MinAngle && angle < MaxAngle) {
				isMoving = true;
				timer = 0;
			}
		}
	}
}
