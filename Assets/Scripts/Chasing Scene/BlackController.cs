using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackController : MonoBehaviour
{
    private GameObject littleElephant;
    public bool isTop;
    // Start is called before the first frame update
    void Start()
    {
        littleElephant = GameObject.Find("LittleElephant");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, (isTop ? 1 : -1) * (littleElephant.transform.position.x - transform.position.x + 30f), 0);
    }
}
