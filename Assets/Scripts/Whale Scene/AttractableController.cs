using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractableController : MonoBehaviour
{

	private SpriteRenderer origin = null;
	private SpriteRenderer mirror = null;
	private Vector3 targetPos;
	private float targetDir;
	private Vector3 defaultPos;
	private float maxDir = 45f;

	private float speed = 0.8f;
	private float maxSpeed = 2.5f;

	private GameObject attractMeat = null;
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
		if (origin == null || mirror == null) {
			origin = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
			mirror = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
		}

		if ((targetPos - transform.position).magnitude > 0.1f) {

			if ((targetPos - transform.position).magnitude < 0.5f && attractMeat != null) {
				Destroy(attractMeat);
				attractMeat = null;
				targetPos = defaultPos;
			}

			Vector3 deltaPos = Vector3.Lerp(transform.position, targetPos, speed) - transform.position;
			deltaPos = deltaPos.magnitude < maxSpeed ? deltaPos : deltaPos.normalized * maxSpeed;
			transform.position += deltaPos * Time.deltaTime;

			targetDir = Mathf.Clamp(Vector3.SignedAngle(new Vector3(deltaPos.x > 0 ? 1 : -1, 0, 0), deltaPos, new Vector3(0, 0, 1)), - maxDir, maxDir);
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z < 90 ? transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z - 360, targetDir, 0.5f));

			origin.enabled = deltaPos.x >= 0;
			mirror.enabled = deltaPos.x < 0;
			
		}

	}

	public bool beAttracted(GameObject meat) {
		if (attractMeat != null) {
			return false;
		}
		attractMeat = meat;
		targetPos = attractMeat.transform.position;
		return true;
	}
}
