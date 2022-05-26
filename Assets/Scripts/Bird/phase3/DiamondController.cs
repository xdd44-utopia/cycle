using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondController : MonoBehaviour
{
	public FoodCollector collector;
	private Animator insectAnim;
	private Animator diamondAnim;
	private bool done = false;
	private bool catched = false;
	private int pick = 0;
	// Start is called before the first frame update
	void Start()
	{
		insectAnim = transform.GetChild(0).GetComponent<Animator>();
		diamondAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x - Camera.main.transform.position.x < 25 && !done) {
			diamondAnim.SetTrigger("Trigger");
			pick = Random.Range(0, 7);
			insectAnim.SetInteger("Type", pick);
			done = true;
		}
	}

	private void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject() || catched)
		{
			return;
		}
		catched = true;
		insectAnim.SetTrigger("Trigger");
		diamondAnim.SetTrigger("Trigger");
		collector.collect(pick);
	}
}
