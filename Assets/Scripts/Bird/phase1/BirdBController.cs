using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBController : MonoBehaviour
{
    public GameObject[] prefabs;
    public int[] order;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void activate()
    {
        foreach(int i in order)
        {

        }
    }
    void generateNote(int type)
    {
        GameObject note=Instantiate(prefabs[type], transform.position, Quaternion.identity, transform.parent);
    }
}
