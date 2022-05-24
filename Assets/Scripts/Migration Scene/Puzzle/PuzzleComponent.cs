using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleComponent : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    private float correctSpeed = 0.1f;
    private float correctAngleRange = 5f;
    private float prevAngle = 0;
    void Start()
    {

    }

    void Update()
    {
        float angle = transform.rotation.eulerAngles.z;
        mPrevPos = Input.mousePosition;
        if (angle > 0 && angle < correctAngleRange) {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(angle, 0, correctSpeed));
        }
        if (angle - 360 < 0 && angle - 360 > -correctAngleRange) {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(angle - 360, 0, correctSpeed));
        }
    }
    private void OnMouseDown()
    {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
        prevAngle = getAngle();
    }
    private void OnMouseDrag()
    {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
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
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + dAngle * 180 / Mathf.PI);
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
        //debug.text = Camera.main.ScreenToWorldPoint(Input.mousePosition) + " " + v + " " + angle * 180 / Mathf.PI;
        return angle;
    }
}