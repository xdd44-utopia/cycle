using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatController : MonoBehaviour
{
    Transform myTransform;
    Vector3 selfScenePosition;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        //将自身坐标转换为屏幕坐标
        selfScenePosition = Camera.main.WorldToScreenPoint(myTransform.position);
        print("scenePosition   :  " + selfScenePosition);
    }
    void OnMouseDrag() //鼠标拖拽时系统自动调用该方法
    {
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
        //将屏幕坐标转换为世界坐标
        Vector3 crrrentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition);
        //设置对象位置为鼠标的世界位置
        myTransform.position = crrrentWorldPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
