using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WormController : MonoBehaviour
{
	private SpriteRenderer sprite;
	private bool activated;
	private float timer;
	private const float appearTime = 2;
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

		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		List<GameObject> spawns = GameObject.FindGameObjectsWithTag("WormSpawn").ToList();
		if (spawns.Count == 0){
			return;
		}
		spawns.Sort(delegate(GameObject s1, GameObject s2) {
			float diff = (s1.transform.position - transform.position).magnitude - (s2.transform.position - transform.position).magnitude;
			return diff == 0 ? 0 : (diff > 0 ? 1 : -1);
		});
		int pick = Random.Range(1, 5);
		for (int i=0;i < pick && i < spawns.Count && (spawns[i].transform.position - transform.position).magnitude < 5;i++) {
			spawns[i].GetComponent<WormSpawnPoint>().spawn();
		}
		
	}
}
