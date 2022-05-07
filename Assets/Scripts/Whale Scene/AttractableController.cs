using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractableController : MonoBehaviour
{
	public bool isCrab;

	private SpriteRenderer origin = null;
	private SpriteRenderer mirror = null;
	protected Vector3 targetPos;
	private float targetDir;
	protected Vector3 defaultPos;
	private Vector3 deltaPos;
	private const float maxDir = 45f;
	private const float speed = 0.8f;
	private const float maxSpeed = 5f;
	protected bool attractable;
	public SceneBehavior scene;

	// Start is called before the first frame update
	protected virtual void Start()
	{
		defaultPos = transform.position;
		targetPos = transform.position;
		targetDir = 0;
		attractable = true;
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		move();
		adjustSprite();
	}

	private void move() {

		if ((targetPos - transform.position).magnitude > 0.1f) {

			deltaPos = Vector3.Lerp(transform.position, targetPos, speed) - transform.position;
			deltaPos = deltaPos.magnitude < maxSpeed ? deltaPos : deltaPos.normalized * maxSpeed;
			transform.position += deltaPos * Time.deltaTime;
			
		}
		else {
			if (targetPos != defaultPos) {
				scene.count();
				defaultPos = targetPos;
			}
		}

	}

	private void adjustSprite() {

		if (!isCrab) {
			targetDir = Mathf.Clamp(Vector3.SignedAngle(new Vector3(deltaPos.x > 0 ? 1 : -1, 0, 0), deltaPos, new Vector3(0, 0, 1)), - maxDir, maxDir);
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z < 90 ? transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z - 360, targetDir, 0.5f));
		}

		if (this.gameObject.transform.childCount != 2) {
			Destroy(this.gameObject);
			return;
		}
		else if (origin == null || mirror == null) {
			origin = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
			mirror = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
		}
		origin.enabled = deltaPos.x >= 0;
		mirror.enabled = deltaPos.x < 0;

	}

	public virtual bool beAttracted(Vector3 p) {
		if (attractable) {
			targetPos = p;
			attractable = false;
			return true;
		}
		else {
			return false;
		}
	} 
}
