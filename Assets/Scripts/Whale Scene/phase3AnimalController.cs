using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScabbardfishController : MonoBehaviour
{
    public SceneBehavior scene;
    public Animator ani;
    private bool isCounted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnMouseDown()
    {
        activate();
    }
    public void activate()
    {
        ani.SetBool("isSwim", true);
        if (!isCounted)
        {
            isCounted = true;
            scene.count();
        }
    }
    public void backToidle()
    {
        ani.SetBool("isSwim", false);
        ani.SetBool("isEat", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") //使用标签
        {
            //销毁食物预制体
            Debug.Log("collider!");
            Destroy(other.gameObject);
            ani.SetBool("isEat", true);
            if (!isCounted)
            {
                isCounted = true;
                scene.count();
            }
        }
    }
}
