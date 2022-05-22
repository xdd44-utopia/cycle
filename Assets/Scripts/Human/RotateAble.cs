using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAble : MonoBehaviour
{
	private float prevAngle = 0;
	public PolygonCollider2D attachCollider;
	public Transform attachTarget;
	private float accAngle;
	public float goalAngle;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Euler(0, 0, -accAngle);
		if (Mathf.Abs(accAngle - goalAngle) < 5) {
			transform.SetParent(attachTarget);
			attachCollider.enabled = true;
			Destroy(this);
		}
	}
	private void OnMouseDown()
	{
		prevAngle = getAngle();
	}
	private void OnMouseDrag()
	{
		float angle = getAngle();
		float dAngle = angle - prevAngle;
		if (dAngle < -Mathf.PI)
		{
			dAngle += Mathf.PI * 2;
		}
		if (dAngle > Mathf.PI)
		{
			dAngle -= Mathf.PI * 2;
		}
		accAngle -= dAngle * 180 / Mathf.PI;
		prevAngle = angle;
	}
	private float getAngle()
	{
		Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = (v.x == 0 ? (v.y > 0 ? Mathf.PI / 2 : Mathf.PI * 3 / 2) : Mathf.Atan(v.y / v.x));
		if (v.x < 0)
		{
			angle += Mathf.PI;
		}
		if (angle < 0)
		{
			angle += Mathf.PI * 2;
		}
		return angle;
	}
}
