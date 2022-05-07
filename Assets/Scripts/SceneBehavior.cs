using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
	public int target;
	public GameObject nextScene;
	private int current;
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
			if (nextScene != null) {
				activateAllAttracting(nextScene);
			}
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

	private void activateAllAttracting(GameObject obj) {
		for (int i=0;i<obj.transform.childCount;i++) {
			activateAllAttracting(obj.transform.GetChild(i).gameObject);
		}
		DraggableAttractingController attracting = obj.GetComponent<DraggableAttractingController>();
		if (attracting != null) {
			attracting.activate();
		}
		
	}

	public void count() {
		current++;
	}
}
