using UnityEngine;

public class CircleController : MonoBehaviour
{
	private float prevAngle = 0;
	[HideInInspector]
	public float accAngle;
	void Start()
	{
		accAngle = 0;
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Euler(0, 0, -accAngle);
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
