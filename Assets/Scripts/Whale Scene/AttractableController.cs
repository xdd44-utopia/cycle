using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractableController : MonoBehaviour
{
	public bool isCrab;

	private SpriteRenderer origin = null;
	private SpriteRenderer mirror = null;
	private Animator originAnim;
	private Animator mirrorAnim;
	private Vector3 originOffset;
	private Vector3 mirrorOffset;
	protected float eatingTime = 0;
	private Vector3 hidePos;
	protected Vector3 targetPos;
	private float targetDir;
	protected Vector3 defaultPos;
	private Vector3 deltaPos;
	private const float maxDir = 60f;
	private const float speed = 0.9f;
	private const float maxSpeed = 5f;
	protected bool attractable;
	public SceneBehavior scene;
	private float zTest;
	// Start is called before the first frame update
	protected virtual void Start()
	{
		zTest = Random.Range(-0.01f, 0.01f);
		if (transform.childCount == 3) {
			GameObject attracting = transform.GetChild(2).gameObject;
			attracting.GetComponent<AttractingController>().setTarget(this);
			attracting.transform.SetParent(transform.parent);

		}

		defaultPos = transform.position;
		if (defaultPos.y > 8) {
			hidePos = new Vector3(defaultPos.x + Random.Range(-10, 10), 16, 0);
		}
		else if (defaultPos.y > -8 || isCrab) {
			hidePos = new Vector3(defaultPos.x > 0 ? 36 : -36, defaultPos.y, 0);
		}
		else {
			hidePos = new Vector3(defaultPos.x + Random.Range(-10, 10), -16, 0);
		}
		targetPos = hidePos;
		transform.position = hidePos;
		targetDir = 0;
		attractable = true;

	}

	// Update is called once per frame
	protected virtual void Update()
	{
		
		if (this.gameObject.transform.childCount != 2) {
			Destroy(this.gameObject);
			return;
		}
		if (origin == null || mirror == null)
		{
			origin = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
			originAnim = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
			mirror = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
			mirrorAnim = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
			originOffset = this.gameObject.transform.GetChild(0).transform.localPosition;
			mirrorOffset = this.gameObject.transform.GetChild(1).transform.localPosition;
		}

		move();
		adjustSprite();

		originAnim.SetBool("isEat", eatingTime > 0);
		mirrorAnim.SetBool("isEat", eatingTime > 0);
		
	}

	private void move() {

		if ((targetPos - transform.position).magnitude > 0.1f) {
            if (isCrab)
            {
				originAnim.SetBool("isWalk", true);
				mirrorAnim.SetBool("isWalk", true);
			}
			deltaPos = Vector3.Lerp(transform.position, targetPos, speed) - transform.position;
			deltaPos = deltaPos.magnitude < maxSpeed ? deltaPos : deltaPos.normalized * maxSpeed;
			transform.position += deltaPos * Time.deltaTime;
		}
		else {
			if (isCrab)
			{
				originAnim.SetBool("isWalk", false);
				mirrorAnim.SetBool("isWalk", false);
			}
			if (!isEating()) {
				wander();
			}
		}
		
		if (eatingTime <= 0) {
			if ((targetPos - transform.position).magnitude < 1f) {
				if (targetPos != defaultPos && targetPos != hidePos) {
					eatingTime = 10000;
					scene.count();
					defaultPos = targetPos;
				}
			}
		}
		else {
			eatingTime -= Time.deltaTime;
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, zTest);
	}

	private void adjustSprite() {

		if (!isCrab && (deltaPos.magnitude > 0.5f || isEating())) {
			targetDir = Mathf.Clamp(Vector3.SignedAngle(new Vector3(deltaPos.x > 0 ? 1 : -1, 0, 0), deltaPos, new Vector3(0, 0, 1)), - maxDir, maxDir);
		}
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z < 90 ? transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z - 360, targetDir, 0.02f));
		

		this.gameObject.transform.GetChild(0).transform.localPosition = isEating() ? originOffset : new Vector3(0, 0, 0);
		this.gameObject.transform.GetChild(1).transform.localPosition = isEating() ? mirrorOffset : new Vector3(0, 0, 0);

		origin.enabled = deltaPos.x >= 0;
		mirror.enabled = deltaPos.x < 0;

	}

	public virtual bool beAttracted(Vector3 p) {
		if (attractable && !isEating()) {
			targetPos = p;
			attractable = false;
			return true;
		}
		else {
			return false;
		}
	}

	public void activate() {
		targetPos = defaultPos;
	}

	public void deactivate() {
		targetPos = hidePos;
		eatingTime = 0;
	}

	private void wander() {
        if (isCrab)
        {
			defaultPos += new Vector3(Random.Range(-10, 10), 0, 0);
		}
        else
        {
			defaultPos += new Vector3(Random.Range(-10, 10), Random.Range(-2, 2), 0);
		}
		defaultPos = new Vector3(
			Mathf.Clamp(defaultPos.x, -32, 32),
			Mathf.Clamp(defaultPos.y, -16, 16),
			0
		);
		targetPos = defaultPos;
	}

	private bool isEating() {
		return (targetPos != defaultPos && targetPos != hidePos) || eatingTime > 0;
	}
}
