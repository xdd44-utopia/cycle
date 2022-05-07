using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
	public int target;
	private int current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current == target) {
			destroyAllSprites(this.GameObject);
			foreach (AttractingController attracting in attractings) {
				attracting.activate();
			}
		}
    }

	private void destroyAllSprites(GameObject obj) {

	}

	private void activateAllAttracting(GameObject obj) {
		
	}

	public void count() {
		current++;
	}
}
