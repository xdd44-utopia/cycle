using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
	public SpriteBehavior[] sprites;
	public AttractingController[] attractings;
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
			foreach (SpriteBehavior sprite in sprites) {
				sprite.destroyThis();
			}
			foreach (AttractingController attracting in attractings) {
				attracting.activate();
			}
		}
    }

	public void count() {
		current++;
	}
}
