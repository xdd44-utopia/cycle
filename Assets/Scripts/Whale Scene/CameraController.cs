using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isUseMoveOnScreenEdge = true;
    private float moveSpeed = 5f;
    private int ScreenEdgeSize = 50;

    private bool MoveUp;
    private bool MoveDown;
    private bool MoveRight;
    private bool MoveLeft;
    private Rect RigthRect;
    private Rect UpRect;
    private Rect DownRect;
    private Rect LeftRect;
    private Vector3 dir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isUseMoveOnScreenEdge)
        {
            UpRect = new Rect(1f, Screen.height - ScreenEdgeSize, Screen.width, ScreenEdgeSize);
            DownRect = new Rect(1f, 1f, Screen.width, ScreenEdgeSize);

            LeftRect = new Rect(1f, 1f, ScreenEdgeSize, Screen.height);
            RigthRect = new Rect(Screen.width - ScreenEdgeSize, 1f, ScreenEdgeSize, Screen.height);


            MoveUp = (UpRect.Contains(Input.mousePosition));
            MoveDown = (DownRect.Contains(Input.mousePosition));

            MoveLeft = (LeftRect.Contains(Input.mousePosition));
            MoveRight = (RigthRect.Contains(Input.mousePosition));

            dir.y = MoveUp ? 1 : MoveDown ? -1 : 0;
            dir.x = MoveLeft ? -1 : MoveRight ? 1 : 0;
            if ((transform.position.x <=-20.6 && dir.x==-1)|| (transform.position.x>=20.6&& dir.x==1))
            {
                dir.x = 0;
            }
            if ((transform.position.y <= -9.85 && dir.y==-1)|| (transform.position.y >= 9.85 && dir.y==1))
            {
                dir.y = 0;
            }

            transform.position = Vector3.Lerp(transform.position, transform.position + dir * moveSpeed, Time.deltaTime);
        }
    }
}
