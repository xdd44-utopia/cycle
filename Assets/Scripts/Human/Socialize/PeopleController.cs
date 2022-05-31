using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
	public Vector3 bubblePoint;
	public Animator drink;
	[HideInInspector]
	public bool isFruit;
	private GameObject bubble;
	public GameObject bubblePrefab;
	public float gapTime;
	public float currentTime;
	// Start is called before the first frame update
	void Start()
	{
		isFruit = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (bubble == null && Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10) {
			if (currentTime > 0) {
				currentTime -= Time.deltaTime;
			}
			else {
				currentTime = gapTime;
				bubble = Instantiate(bubblePrefab, transform.position+bubblePoint, Quaternion.identity, transform);
			}
		}
		if (gapTime > 0) {
			gapTime -= Time.deltaTime * 0.05f;
		}
	}
	public void change() {
		if (isFruit) {
			return;
		}
		this.GetComponent<Animator>().SetTrigger("Trigger");
		drink.SetTrigger("Trigger");
		isFruit = true;
	}
}
