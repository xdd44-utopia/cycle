using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    private float destroyTime = 3;
    private float timer;
    private bool isVanishing = false;
    SpriteRenderer sprite;
    // Start is called before the first frame update
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
    void onMouseDrag()
    {
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        //将屏幕坐标转换为世界坐标
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
        //设置对象位置为鼠标的世界位置
        transform.localPosition = currentWorldPosition;
    }
    protected virtual void OnMouseUp()
    {
        
        isVanishing = true;
        timer = 0;
    }
}
