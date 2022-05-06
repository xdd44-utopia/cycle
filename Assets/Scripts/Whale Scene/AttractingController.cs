using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractingController : MonoBehaviour
{
	public AttractableController target;
	public int automateTime;
	public SceneBehavior scene;
	private float timer = 0;
	private PolygonCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (automateTime > 0) {
			timer += Time.deltaTime;
			if (timer > automateTime) {
				activate();
				automateTime = -1;
			}
		}
    }

	void OnMouseDown() {
		activate();
	}

	public void activate() {
		target.beAttracted(transform.position);
		collider.enabled = true;
		scene.count();
	}


}
