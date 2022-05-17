using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject par;
    public bool isOut;
    void Start()
    {
        par = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (isOut) {
            par.GetComponent<HumanPhaseController>().moveToNext();
            
        }
        else {
            par.GetComponent<HumanPhaseController>().moveToPrevious();
            
        }
        
    }
}
