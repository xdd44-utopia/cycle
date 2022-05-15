using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private float destroyTime = 3;
    private float timer;
    private Vector3 selfScenePosition;
    private Vector3 originalPosition;
    private bool isVanishing = false;
    private bool isAway = false;
    public GameObject[] prefabs;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
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
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z);
        //将屏幕坐标转换为世界坐标
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
        //设置对象位置为鼠标的世界位置
        transform.localPosition = currentWorldPosition;
        isAway = true;

    }
    protected virtual void OnMouseUp()
    {
        Instantiate(prefabs[(int)Random.Range(0, 3)], originalPosition, Quaternion.identity, transform.parent);
        isVanishing = true;
        timer = 0;
    }

}
