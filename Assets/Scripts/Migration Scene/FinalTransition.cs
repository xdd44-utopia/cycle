using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(19 / transform.parent.localScale.x, 10.6f / transform.parent.localScale.x, 1 / transform.parent.localScale.x);
    }
}
