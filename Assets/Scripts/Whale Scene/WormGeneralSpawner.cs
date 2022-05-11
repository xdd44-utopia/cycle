using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGeneralSpawner : MonoBehaviour
{
	public SceneBehavior scene;
	private float timer;
	void Start()
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer > 5) {
			GameObject[] spawns = GameObject.FindGameObjectsWithTag("WormSpawn");
			if (spawns.Length < 50) {
				scene.count();
				Destroy(this.gameObject);
				return;
			}
			else {
				spawns[(int)Random.Range(0, spawns.Length)].GetComponent<WormSpawnPoint>().spawn();
			}
			timer = 0;
		}
	}
}
