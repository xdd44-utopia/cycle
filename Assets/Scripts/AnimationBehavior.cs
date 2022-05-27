using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    private AudioManager audioManager;
    private Animator animator;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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

    public void disableAnimation() {
        animator.enabled = false;
    }

    public void playAudio(int audioID) {
        audioManager.playClip(audioID);
    }
}
