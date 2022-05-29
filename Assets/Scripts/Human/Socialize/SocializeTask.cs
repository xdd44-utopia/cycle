using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocializeTask : MonoBehaviour
{
    public GameObject[] people;
    private bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        isFinished = true;
        for(int i = 0; i < 4; i++)
        {
            if (!people[i].GetComponent<PeopleController>().isFruit)
            {
                isFinished = false;
                break;
            }
        }
        if (isFinished)
        {

        }
    }
}
