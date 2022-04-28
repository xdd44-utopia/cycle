using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Animator[] animators;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        foreach (Animator ani in animators)
        {
            ani.SetBool("Trigger", true);

        }
    }
    public void delete()
    {
        Destroy(gameObject);
    }
}
