using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
	private SpriteRenderer sprite;
	private bool activated;
	private float timer;
	private const float appearTime = 3;
	// Start is called before the first frame update
	void Start()
	{
		activated = false;
		timer = 0;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 1, 1, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (!activated) {
			sprite.color = new Color(1, 1, 1, timer / appearTime);
			timer += Time.deltaTime;
			if (timer > appearTime) {
				activated = true;
			}
		}
	}

	void OnMouseDown() {

		GameObject[] spawns = GameObject.FindGameObjectsWithTag("WormSpawn");
		int temp = Random.Range(1, 5);
		for (int t=0; t< temp; t++)
        {
			if (spawns.Length == 0)
			{
				return;
			}
			else
			{
				int mini = 0;
				float minDist = 2147483647;
				for (int i = 0; i < spawns.Length; i++)
				{
					if ((spawns[i].transform.position - transform.position).magnitude < minDist)
					{
						minDist = (spawns[i].transform.position - transform.position).magnitude;
						mini = i;
					}
				}
				spawns[mini].GetComponent<WormSpawnPoint>().spawn();
			}
		}
		
	}
}
