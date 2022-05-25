using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondController : MonoBehaviour
{
    private Animator insectAnim;
    private Vector3 maincam ;
    public int distance;
    private Animator diamondAnim;
    private bool isdone;
    // Start is called before the first frame update
    void Start()
    {
        insectAnim = transform.GetChild(0).GetComponent<Animator>();
        isdone = false;
    }

    // Update is called once per frame
    void Update()
    {
        maincam = GameObject.Find("Main Camera").transform.position;
        if (Mathf.Abs(maincam.x-transform.position.x)<distance&&!isdone)
        {
            diamondAnim.SetTrigger("Trigger");
            insectAnim.SetInteger("Type", Random.Range(1, 7));
            isdone = true;
        }
    }
    protected virtual void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        insectAnim.SetTrigger("Trigger");
        diamondAnim.SetTrigger("Trigger");
    }
}
