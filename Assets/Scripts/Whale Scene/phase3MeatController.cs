
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class phase3MeatController : MonoBehaviour
{
    private Vector3 selfScenePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
        //将屏幕坐标转换为世界坐标
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
        //设置对象位置为鼠标的世界位置
        transform.position = new Vector3(currentWorldPosition.x, currentWorldPosition.y, 0);
    }

}