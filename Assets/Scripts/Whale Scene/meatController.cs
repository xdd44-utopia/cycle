using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
	private Vector3 selfScenePosition;
	private bool hasAttracted = false;
	private const float attractDist = 5f;
	// Start is called before the first frame update
	void Start()
	{
		//将自身坐标转换为屏幕坐标
		selfScenePosition = Camera.main.WorldToScreenPoint(transform.position);
	}
	void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
	{
		if (!hasAttracted) {
			Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
			//将屏幕坐标转换为世界坐标
			Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
			//设置对象位置为鼠标的世界位置
			transform.position = currentWorldPosition;

			GameObject[] attractables = GameObject.FindGameObjectsWithTag("Attractable");
			foreach (GameObject attractable in attractables) {
				if ((attractable.transform.position - transform.position).magnitude < attractDist) {
					hasAttracted = attractable.GetComponent<AttractableController>().beAttracted(this.gameObject);
				}
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		
	}

}
