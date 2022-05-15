using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase3AnimalController : MonoBehaviour
{
	public SceneBehavior scene;
	public bool isSeaanemone;
	public bool isOctopus;
	private Animator anime;
	private bool isCounted = false;
	private bool isDeactivated = false;
	protected Vector3 targetPos;
	private float targetDir;
	private Vector3 deltaPos;

	private const float speed = 0.9f;
	private const float maxSpeed = 5f;
	private const float maxDir = 60f;
	// Start is called before the first frame update
	void Start()
	{
		anime = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
        if (isOctopus&&anime.GetBool("isSwim"))
        {
			move();
			adjustSprite();
		}
		
		if (isDeactivated && !isSeaanemone) {
			transform.position += new Vector3(0, 0.1f, 0);
		}
	}
	private void move()
	{

		if ((targetPos - transform.position).magnitude > 0.1f)
		{
			deltaPos = Vector3.Lerp(transform.position, targetPos, speed) - transform.position;
			deltaPos = deltaPos.magnitude < maxSpeed ? deltaPos : deltaPos.normalized * maxSpeed;
			transform.position += deltaPos * Time.deltaTime;
		}
	}
	private void adjustSprite()
	{
		targetDir = Mathf.Clamp(Vector3.SignedAngle(new Vector3(0, 1, 0), deltaPos, new Vector3(0, 0, 1)), -maxDir, maxDir);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z < 90 ? transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z -360, targetDir, 0.02f));
	}
	protected virtual void OnMouseDown()
	{
		activate();
	}
	public void activate()
	{
		anime.SetBool("isSwim", true);
        if (isOctopus)
        {
			targetPos = transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
		}
		if (!isCounted)
		{
			isCounted = true;
			scene.count();
		}
	}
	public void backToidle()
	{
		anime.SetBool("isSwim", false);
		anime.SetBool("isEat", false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Food")
		{
			Destroy(other.gameObject);
			anime.SetBool("isEat", true);
			if (!isCounted)
			{
				isCounted = true;
				scene.count();
			}
		}
	}

	public void deactivate() {
		isDeactivated = true;
	}
}
