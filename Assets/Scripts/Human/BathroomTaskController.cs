using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTaskController : MonoBehaviour
{
    public int MinAngle;
    public int MaxAngle;
    public float threshold;
    public float goal;
    private Transform mask;
    private float acc;
    private Vector3 preMousepos;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        mask = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(acc);
        if (isMoving)
        {
            acc += Time.deltaTime;
        }
        if (acc > goal) { Debug.Log("Success"); }

    }
    protected virtual void OnMouseDrag()
    {
        Vector3 deltapos = Input.mousePosition - preMousepos;
        if (deltapos.y != 0 && deltapos.x != 0)
        {
            float angle = Mathf.Atan(Mathf.Abs(deltapos.y) / Mathf.Abs(deltapos.x));
            angle = angle * 180 / Mathf.PI;
            if (deltapos.magnitude > threshold && angle > MinAngle && angle < MaxAngle)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        preMousepos = Input.mousePosition;
    }
}
