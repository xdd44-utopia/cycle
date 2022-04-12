using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
	public GameObject elephant;
	public SpriteRenderer sprite;
	public bool isDarken;
	public SpriteRenderer[] bkgs;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		sprite.color = new Color(1, 1, 1, (30 - 10 - this.transform.position.x + elephant.transform.position.x) / 30);
		if (this.transform.position.x - elephant.transform.position.x + 10 > 0) {
			foreach (SpriteRenderer bkg in bkgs) {
				bkg.color = isDarken ? sprite.color : new Color(1, 1, 1, 1 - sprite.color.a);
			}
		}
	}
}
