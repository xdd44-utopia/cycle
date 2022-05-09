using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isUseMoveOnScreenEdge = true;
    private float moveSpeed = 5f;

    private bool MoveUp;
    private bool MoveDown;
    private bool MoveRight;
    private bool MoveLeft;
    private Rect RigthRect;
    private Rect UpRect;
    private Rect DownRect;
    private Rect LeftRect;
    private Vector3 dir = Vector3.zero;
	private Camera cam;
	private float maxWidth = 35f;
	private float maxHeight = 15f;
    // Start is called before the first frame update
    void Start()
    {
		cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUseMoveOnScreenEdge)
        {
            UpRect = new Rect(0, 2 * Screen.height / 3, Screen.width, Screen.height / 3);
            DownRect = new Rect(0, 0, Screen.width, Screen.height / 3);

            LeftRect = new Rect(0, 0, Screen.width / 3, Screen.height);
            RigthRect = new Rect(2 * Screen.width / 3, 0, Screen.width / 3, Screen.height);


            MoveUp = (UpRect.Contains(Input.mousePosition));
            MoveDown = (DownRect.Contains(Input.mousePosition));

            MoveLeft = (LeftRect.Contains(Input.mousePosition));
            MoveRight = (RigthRect.Contains(Input.mousePosition));

            dir.y = MoveUp ? 1 : MoveDown ? -1 : 0;
            dir.x = MoveLeft ? -1 : MoveRight ? 1 : 0;

            transform.position = Vector3.Lerp(transform.position, transform.position + dir * moveSpeed, Time.deltaTime);
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, - maxWidth + cam.orthographicSize * cam.aspect, maxWidth - cam.orthographicSize * cam.aspect),
				Mathf.Clamp(transform.position.y, - maxHeight + cam.orthographicSize, maxHeight - cam.orthographicSize), 
				-20
			);
        }
    }
}
