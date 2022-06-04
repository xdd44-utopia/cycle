using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelTask1 : MonoBehaviour
{
	public Animator scene;
	public SpriteRenderer[] upperSprites;
	public SpriteRenderer[] lowerSprites;
	public bool[] upperAnswer;
	public bool[] lowerAnswer;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (
			(!upperSprites[0].enabled ^ upperAnswer[0]) &&
			(!upperSprites[1].enabled ^ upperAnswer[1]) &&
			(!upperSprites[2].enabled ^ upperAnswer[2]) &&
			(!upperSprites[3].enabled ^ upperAnswer[3]) &&
			(!upperSprites[4].enabled ^ upperAnswer[4]) &&
			(!lowerSprites[0].enabled ^ lowerAnswer[0]) &&
			(!lowerSprites[1].enabled ^ lowerAnswer[1]) &&
			(!lowerSprites[2].enabled ^ lowerAnswer[2]) &&
			(!lowerSprites[3].enabled ^ lowerAnswer[3]) &&
			(!lowerSprites[4].enabled ^ lowerAnswer[4])
		) {
			scene.SetTrigger("Trigger");
			Destroy(this);
		}
	}

	public void switchSprite(bool isUpper, int id) {
		if (isUpper) {
			if (id > 0) {
				upperSprites[id - 1].enabled = !upperSprites[id - 1].enabled;
			}
			if (id < 4) {
				upperSprites[id + 1].enabled = !upperSprites[id + 1].enabled;
			}
		}
		else {
			if (id > 0) {
				lowerSprites[id - 1].enabled = !lowerSprites[id - 1].enabled;
			}
			if (id < 4) {
				lowerSprites[id + 1].enabled = !lowerSprites[id + 1].enabled;
			}
		}
	}
}
