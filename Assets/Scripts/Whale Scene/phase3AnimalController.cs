using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase3AnimalController : MonoBehaviour
{
	public SceneBehavior scene;
	private Animator anime;
	private bool isCounted = false;
	// Start is called before the first frame update
	void Start()
	{
		anime = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		
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
		if (other.tag == "Food") //使用标签
		{
			//销毁食物预制体
			Debug.Log("collider!");
			Destroy(other.gameObject);
			anime.SetBool("isEat", true);
			if (!isCounted)
			{
				isCounted = true;
				scene.count();
			}
		}
	}
}
