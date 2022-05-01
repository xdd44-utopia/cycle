using UnityEngine;

public class Arc5Controller : MonoBehaviour
{

	public Animator[] animators;
	public NewbornCameraController scene;
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

	public void enableScene() {
		scene.startScene();
	}


}
