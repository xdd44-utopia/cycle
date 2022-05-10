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
			destroyAllSprites(this.gameObject);
			deactivateAllAttractable(this.gameObject);
			if (nextScene != null) {
				nextScene.activate();
			}
		}
		if (activated && Camera.main.orthographicSize != cameraSize) {
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, 0.01f);
		}
    }

	private void destroyAllSprites(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			destroyAllSprites(obj.transform.GetChild(i).gameObject);
		}
		SpriteBehavior sprite = obj.GetComponent<SpriteBehavior>();
		if (sprite != null) {
			sprite.destroyThis();
		}
	}
	private void deactivateAllAttractable(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			deactivateAllAttractable(obj.transform.GetChild(i).gameObject);
		}
		AttractableController attractable = obj.GetComponent<AttractableController>();
		if (attractable != null) {
			attractable.deactivate();
		}
	}

	public void activate() {
		activated = true;
		activateAllAttracting(this.gameObject);
		activateAllAttractable(this.gameObject);
		activateAllSpawn(this.gameObject);
	}

	private void activateAllAttracting(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			activateAllAttracting(obj.transform.GetChild(i).gameObject);
		}
		DraggableAttractingController attracting = obj.GetComponent<DraggableAttractingController>();
		if (attracting != null) {
			attracting.activate();
		}
	}
	private void activateAllAttractable(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			activateAllAttractable(obj.transform.GetChild(i).gameObject);
		}
		AttractableController attractable = obj.GetComponent<AttractableController>();
		if (attractable != null) {
			attractable.activate();
		}
	}
	private void activateAllSpawn(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			activateAllSpawn(obj.transform.GetChild(i).gameObject);
		}
		WormSpawnPoint spawn = obj.GetComponent<WormSpawnPoint>();
		if (spawn != null) {
			spawn.activate();
		}
	}


	public void count() {
		current++;
	}
}
