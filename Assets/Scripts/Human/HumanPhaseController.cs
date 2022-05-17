using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPhaseController : MonoBehaviour
{
    public GameObject previousPhase;
    public GameObject nextPhase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveToPrevious()
    {
        previousPhase.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void moveToNext()
    {
        
        nextPhase.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
