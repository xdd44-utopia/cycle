using UnityEngine;

public class ArcController : MonoBehaviour
{

    public Animator[] animators;
    public PuzzleController puzzle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchStates() {
        foreach (Animator ani in animators) {
            ani.SetBool("Trigger", true);
        }
    }

    public void enablePuzzle() {
        puzzle.switchStates();
    }


}
