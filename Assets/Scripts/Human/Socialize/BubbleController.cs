using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator drink;
    public SpriteRenderer Greenbg;
    public SpriteRenderer Redbg;
    public SpriteRenderer[] Icons;
    public float MaxWaitTime;
    public float GoalTime;
    private float acc;
    private float accSpeed=2;
    private float decaySpeed=1;
    void Start()
    {
        acc = 0;
        int openIcon = Random.Range(0, 5);
        for(int i = 0; i < 5; i++)
        {
            if (i == openIcon)
            {
                Icons[i].enabled = true;
            }
            else
            {
                Icons[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (acc > GoalTime)
        {
            
            Debug.Log("success");
            Destroy(this.gameObject);
        }
        else if(acc<-MaxWaitTime)
        {
            Debug.Log("Defeat");
            transform.parent.gameObject.GetComponent<PeopleController>().change();
            Destroy(this.gameObject);
        }
        else if(acc>0)
        {
            Redbg.color = new Color(1, 1, 1, 0);
            Greenbg.color = new Color(1, 1, 1, acc / GoalTime);
        }
        else
        {
            Redbg.color = new Color(1, 1, 1, -acc/MaxWaitTime);
            Greenbg.color = new Color(1, 1, 1, 0);
        }
        acc -= Time.deltaTime * decaySpeed;
    }
    private void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        acc += Time.deltaTime*accSpeed;
    }
}
