using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPhaseAttractableController : AttractableController
{
	public int automateTime;
	private float timer = 0;
	private GameObject attracting;
	private const float attractDist = 5f;
	private bool hasAttracted = false;

	protected override void Start() {
		base.Start();
		attractable = false;
		attracting = null;
	}

	protected override void Update() {
		base.Update();
		if ((targetPos - transform.position).magnitude < 0.5f && attracting != null) {
			if (attracting.GetComponent<SpriteBehavior>() != null) {
				attracting.GetComponent<SpriteBehavior>().destroyThis();
			}
			else {
				Destroy(attracting);
			}
			eatingTime = 4;
			attracting = null;
			attractable = true;
		}
		if (automateTime > 0) {
			timer += Time.deltaTime;
			if (timer > automateTime) {
				attractable = true;
				automateTime = -1;
			}
		}
	}

	public bool beAttracted(GameObject meat) {
		if (attracting != null || attractable || hasAttracted) {
			return false;
		}
		else if ((meat.transform.position - transform.position).magnitude < attractDist && (!isCrab || Mathf.Abs(meat.transform.position.y - transform.position.y) < 0.4f)) {
			attracting = meat;
			targetPos = attracting.transform.position;
			hasAttracted = true;
			return true;
		}

		else {
			return false;
		}
	}

}