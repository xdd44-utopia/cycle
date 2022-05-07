using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractableController : MonoBehaviour
{
	public bool isCrab;

	private SpriteRenderer origin = null;
	private SpriteRenderer mirror = null;
	private Vector3 targetPos;
	private float targetDir;
	private Vector3 defaultPos;
	private const float maxDir = 45f;
	private const float attractDist = 5f;
	private const float speed = 0.8f;
	private const float maxSpeed = 5f;

	private GameObject attracting = null;
	// Start is called before the first frame update
	void Start()
	{
		defaultPos = transform.position;
		targetPos = transform.position;
		targetDir = 0;
		transform.position = new Vector3(-35, 15, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (this.gameObject.transform.childCount == 0) {
			Destroy(this.gameObject);
		}
		if (origin == null || mirror == null) {
			origin = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
			mirror = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
		}

		if ((targetPos - transform.position).magnitude > 0.1f) {

			if ((targetPos - transform.position).magnitude < 0.5f && attracting != null) {
				if (attracting.GetComponent<SpriteBehavior>() != null) {
					attracting.GetComponent<SpriteBehavior>().destroyThis();
				}
				else {
					Destroy(attracting);
				}
				attracting = null;
				targetPos = defaultPos;
			}

			Vector3 deltaPos = Vector3.Lerp(transform.position, targetPos, speed) - transform.position;
			deltaPos = deltaPos.magnitude < maxSpeed ? deltaPos : deltaPos.normalized * maxSpeed;
			transform.position += deltaPos * Time.deltaTime;

			if (!isCrab) {
				targetDir = Mathf.Clamp(Vector3.SignedAngle(new Vector3(deltaPos.x > 0 ? 1 : -1, 0, 0), deltaPos, new Vector3(0, 0, 1)), - maxDir, maxDir);
				transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z < 90 ? transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z - 360, targetDir, 0.5f));
			}

			origin.enabled = deltaPos.x >= 0;
			mirror.enabled = deltaPos.x < 0;
			
		}

	}

	public bool beAttracted(GameObject meat) {
		if (attracting != null) {
			return false;
		}
		else if ((meat.transform.position - transform.position).magnitude < attractDist && (!isCrab || Mathf.Abs(meat.transform.position.y - transform.position.y) < 0.4f)) {
			attracting = meat;
			targetPos = attracting.transform.position;
			return true;
		}
		else {
			return false;
		}
	}

	public void beAttracted(Vector3 p) {
		if (attracting == null) {
			targetPos = p;
		}
	} 
}
