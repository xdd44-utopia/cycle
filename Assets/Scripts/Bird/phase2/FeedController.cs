using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedController : MonoBehaviour
{
    public Animator anim;
    private int count;
    public int goal;
    public GameObject[] insects;
    private GameObject current;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        current = Instantiate(insects[count], new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (count == goal)
        {
            Destroy(current);
            anim.SetTrigger("Trigger");
        }
        else
        {
            Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
            current.transform.position = currentWorldPosition;
        }

    }
    public void addCount()
    {
        Destroy(current);
        count += 1;
        if (count < goal)
        {
            current = Instantiate(insects[count], new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }
}
