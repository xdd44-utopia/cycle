using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractingController : MonoBehaviour
{
	public AttractableController target;
	public int automateTime;
	public SceneBehavior scene;
	public bool movable;
	private float timer = 0;
	private PolygonCollider2D collider;
	private Vector3 selfScenePosition;
	private bool hasAttracted = false;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
		selfScenePosition = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (automateTime > 0) {
			timer += Time.deltaTime;
			if (timer > automateTime) {
				activate();
				automateTime = -1;
			}
		}
    }

	void OnMouseDown() {
		if (!movable) {
			activate();
		}
	}

	public void activate() {
		if (!movable) {
			target.beAttracted(transform.position);
			scene.count();
		}
		collider.enabled = true;
	}
	void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
	{
		if (!hasAttracted && movable) {
			Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
			//将屏幕坐标转换为世界坐标
			Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
			//设置对象位置为鼠标的世界位置
			transform.position = currentWorldPosition;

			GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
			foreach (GameObject attractable in attractables) {
				hasAttracted = attractable.GetComponent<AttractableController>().beAttracted(this.gameObject);
				if (hasAttracted) {
					break;
				}
			}
		}
	}


}
