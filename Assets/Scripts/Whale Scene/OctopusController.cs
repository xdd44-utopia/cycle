using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
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
    }
}
