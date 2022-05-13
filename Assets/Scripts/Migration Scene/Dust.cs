using UnityEngine;

public class Dust : MonoBehaviour
{
	public GameObject elephant;
	public SpriteRenderer sprite;
	public bool isDarken;
	public SpriteRenderer[] bkgs;
	public Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		sprite.color = new Color(1, 1, 1, (30 - 10 - this.transform.position.x + elephant.transform.position.x) / 30);
		if (this.transform.position.x - elephant.transform.position.x + 10 > 0 && this.transform.position.x - elephant.transform.position.x + 10 < 40) {
			foreach (SpriteRenderer bkg in bkgs) {
				bkg.color = isDarken ? sprite.color : new Color(1, 1, 1, 1 - sprite.color.a);
			}
		}
		if (elephant.transform.position.x - this.transform.position.x > 0 && elephant.transform.position.x - this.transform.position.x < 10) {
			anim.SetBool("Dark", isDarken);
		}
		else if (elephant.transform.position.x - this.transform.position.x < 0 && elephant.transform.position.x - this.transform.position.x > -10) {
			anim.SetBool("Dark", !isDarken);
		}
	}
}
