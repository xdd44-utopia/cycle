using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehavior : MonoBehaviour
{
	private float destroyTime = 5;
	private SpriteRenderer sprite;
	private float timer;
	private bool isVanishing = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVanishing) {
			timer += Time.deltaTime;
			if (timer > destroyTime) {
				Destroy(this.gameObject);
			}
			sprite.color = new Color(1, 1, 1, 1 - timer / destroyTime);
		}
    }

	public void destroyThis() {
		isVanishing = true;
		timer = 0;
	}
}
