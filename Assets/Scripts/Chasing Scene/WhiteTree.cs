using UnityEngine;

public class WhiteTree : MonoBehaviour
{
	private GameObject elephant;
	private bool isEaten = false;
	private float alpha = 3f;
	private float vanishRate = 0.5f;
	// Start is called before the first frame update
	void Start()
	{
		elephant = GameObject.Find("Elephant");
	}

	// Update is called once per frame
	void Update()
	{
		if (isEaten) {
			alpha -= vanishRate * Time.deltaTime;
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha < 1 ? alpha : 1);
			if (alpha <= 0) {
				Destroy(gameObject);
			}
		}
	}

	private void OnMouseDown() {
		if (Mathf.Abs(elephant.transform.position.x + 4f - transform.position.x) < 2f && !isEaten) {
			elephant.GetComponent<ElephantController>().eating = true;
			isEaten = true;
		}
	}
}
