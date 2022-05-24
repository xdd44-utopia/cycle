using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerableAnimationBehavior : MonoBehaviour
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

	public void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		enableTrigger();
	}

    public void enableTrigger() {
        animator.SetBool("Trigger", true);
    }

    public void disableTrigger() {
        animator.SetBool("Trigger", false);
    }
    public void distroyThis() {
        Destroy(this.gameObject);
    }
}
