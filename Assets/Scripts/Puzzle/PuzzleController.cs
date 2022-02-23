using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    public SpriteRenderer[] spriteRenderers;
    public Animator[] animators;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            switchStates();
        }
    }

    public void switchStates() {
        foreach (Animator ani in animators) {
            ani.SetBool("Trigger", true);
        }
    }


}
