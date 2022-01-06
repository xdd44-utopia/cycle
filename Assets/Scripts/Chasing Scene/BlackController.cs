using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackController : MonoBehaviour
{
    public GameObject littleElephant;
    public bool isTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, (isTop ? 1 : -1) * (littleElephant.transform.localPosition.x + 30f), 0);
    }
}
