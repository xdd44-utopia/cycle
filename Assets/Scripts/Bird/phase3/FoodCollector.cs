using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
	public BirdSubSceneSwitch scene;
	public Sprite[] sprites;
	public SpriteRenderer[] starvings1;
	public SpriteRenderer[] starvings2;
	public SpriteRenderer[] starvings3;
	public SpriteRenderer[] feds1;
	public SpriteRenderer[] feds2;
	public SpriteRenderer[] feds3;
	[HideInInspector]
	public bool isCollecting;
	private List<SpriteRenderer> insects = new List<SpriteRenderer>();
	private int count = 0;
	private int fed = 0;
	// Start is called before the first frame update
	void Start()
	{
		isCollecting = false;
		for (int i=0;i<transform.childCount;i++) {
			insects.Add(transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
		}
		for (int i=0;i<4;i++) {
			feds1[i].enabled = false;
			feds2[i].enabled = false;
			feds3[i].enabled = false;
			starvings1[i].enabled = true;
			starvings2[i].enabled = true;
			starvings3[i].enabled = true;
		}
		for (int i=0;i<fed;i++) {
			feds1[i].enabled = true;
			feds2[i].enabled = true;
			feds3[i].enabled = true;
			starvings1[i].enabled = false;
			starvings2[i].enabled = false;
			starvings3[i].enabled = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		for (int i=0;i<insects.Count;i++) {
			insects[i].enabled = false;
		}
		if (!isCollecting) {
			for (int i=0;i<count;i++) {
				insects[i].enabled = true;
			}
		}
	}

	public void collect(int id) {
		insects[count].sprite = sprites[id];
		count++;
		fed = 0;
	}

	public void feed() {
		count--;
		fed++;
		if (count == 0) {
			scene.nextScene();
		}
	}

}
