using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part1 : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    public float speed = 10f;//旋转速度
    private float prevAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mPrevPos = Input.mousePosition;

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