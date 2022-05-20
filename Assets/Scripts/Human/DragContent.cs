using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContent : MonoBehaviour
{
    private Transform content;
    
    // Start is called before the first frame update
    void Start()
    {
        content = this.gameObject.transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        
    }
}
