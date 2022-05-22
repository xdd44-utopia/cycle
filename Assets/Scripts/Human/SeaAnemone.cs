using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAnemone : MonoBehaviour
{
    private float destroyTime = 3;
    private float timer;
    private bool isVanishing = false;
    // Start is called before the first frame update
    SpriteRenderer sprite;
    void Start()
    {
        sprite = this.gameObject.transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVanishing)
        {
            timer += Time.deltaTime;
            if (timer > destroyTime)
            {
                Destroy(this.gameObject);
            }
            sprite.color = new Color(1, 1, 1, 1 - timer / destroyTime);
        }
    }
    protected virtual void OnMouseDrag()
    {
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Debug.Log("Input.mousePosition" + Input.mousePosition);
        //将屏幕坐标转换为世界坐标
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
        //设置对象位置为鼠标的世界位置
        Debug.Log("currentWorldPosition" + currentWorldPosition);
        transform.position = currentWorldPosition;


    }
    protected virtual void OnMouseUp()
    {
        isVanishing = true;
        timer = 0;
    }

}
