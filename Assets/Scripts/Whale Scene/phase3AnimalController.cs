using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase3AnimalController : MonoBehaviour
{
	public SceneBehavior scene;
	public bool isSeaanemone;
	private Animator anime;
	private bool isCounted = false;
	private bool isDeactivated = false;
	// Start is called before the first frame update
	void Start()
	{
		anime = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isDeactivated && !isSeaanemone) {
			transform.position += new Vector3(0, 0.1f, 0);
		}
	}
	protected virtual void OnMouseDown()
	{
		activate();
	}
	public void activate()
	{
		anime.SetBool("isSwim", true);
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
