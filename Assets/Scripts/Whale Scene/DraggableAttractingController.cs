using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableAttractingController : AttractingController {

	private PolygonCollider2D collider;
	private Vector3 selfScenePosition;
	private bool hasAttracted = false;

	protected override void Start()
	{
		collider = GetComponent<PolygonCollider2D>();
		selfScenePosition = Camera.main.WorldToScreenPoint(transform.position);
	}

	public override void activate() {
		collider.enabled = true;
	}
	protected override void OnMouseDown() {
		
	}

	void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
	{
		if (!hasAttracted) {
			Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
			//将屏幕坐标转换为世界坐标
			Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
			//设置对象位置为鼠标的世界位置
			transform.position = new Vector3(currentWorldPosition.x, currentWorldPosition.y, 0);

			GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
			foreach (GameObject attractable in attractables) {
				hasAttracted = attractable.GetComponent<TwoPhaseAttractableController>().beAttracted(this.gameObject);
				if (hasAttracted) {
					break;
				}
			}
		}
	}

}