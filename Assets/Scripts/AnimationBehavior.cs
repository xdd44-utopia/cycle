using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableTrigger() {
        animator.SetBool("Trigger", true);
    }

    public void disableTrigger() {
        animator.SetBool("Trigger", false);
    }
}
