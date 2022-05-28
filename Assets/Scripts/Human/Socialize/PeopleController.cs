using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    public Vector3 bubblePoint;
    public bool isFruit;
    private GameObject bubble;
    public GameObject bubblePrefab;
    public float gapTime;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        isFruit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble == null)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = gapTime;
                bubble=Instantiate(bubblePrefab, transform.position+bubblePoint, Quaternion.identity, transform);
            }
        }
    }
    public void change()
    {
        this.GetComponent<Animator>().SetTrigger("Trigger");
        isFruit = true;
    }
}
