using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    
    public GameObject head;
    public float speed;
    public float rotateOffset;
    private Vector2 target;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.Find("head").gameObject;
    }
    private void FollowMouseRotate()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(head.transform.position);
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        direction = direction.normalized;
        transform.up = direction;
    }
    private void FollowMouseMove()
    {
        float moveSpeed = 3.0f;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 0;
        Vector3 objpos = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - objpos.x;
        mousepos.y = mousepos.y - objpos.y;
        float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle+rotateOffset));
        
        Vector2 mousePos = new Vector2();

        // compute where the mouse is in world space
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - Input.mousePosition.y;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
}
