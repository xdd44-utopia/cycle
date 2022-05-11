using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
	public int target;
	public float cameraSize;
	public SceneBehavior nextScene;
	private int current;
	private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (current == target) {
			target = -1;
			deactivateRecursive(this.gameObject);
			if (nextScene != null) {
				nextScene.activate();
			}
		}
		if (activated && Camera.main.orthographicSize != cameraSize) {
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, 0.01f);
		}
    }

	public void activate() {
		activated = true;
		activateRecursive(this.gameObject);
	}

	private void activateRecursive(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			activateRecursive(obj.transform.GetChild(i).gameObject);
		}
		DraggableAttractingController attracting = obj.GetComponent<DraggableAttractingController>();
		if (attracting != null) {
			attracting.activate();
		}
		AttractableController attractable = obj.GetComponent<AttractableController>();
		if (attractable != null) {
			attractable.activate();
		}
		WormSpawnPoint spawn = obj.GetComponent<WormSpawnPoint>();
		if (spawn != null) {
			spawn.activate();
		}
	}

	private void deactivateRecursive(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			deactivateRecursive(obj.transform.GetChild(i).gameObject);
		}
		SpriteBehavior sprite = obj.GetComponent<SpriteBehavior>();
		if (sprite != null) {
			sprite.destroyThis();
		}
		AttractableController attractable = obj.GetComponent<AttractableController>();
		if (attractable != null) {
			attractable.deactivate();
		}
		phase3AnimalController animal = obj.GetComponent<phase3AnimalController>();
		if (animal != null) {
			animal.deactivate();
		}
	}
	public void count() {
		current++;
	}
}
