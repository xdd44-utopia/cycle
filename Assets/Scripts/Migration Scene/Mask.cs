using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private float timer = 0;
	private float duration = 1f;
	private bool appearing = true;
	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(1, 1, 1, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (appearing) {
			timer += Time.deltaTime;
			spriteRenderer.color = new Color(1, 1, 1, timer / duration);
			if (timer >= duration) {
				appearing = false;
			}
		}
	}

	public void activate() {
		appearing = true;
	}
}
