using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawnPoint : MonoBehaviour
{
	public GameObject[] prefabs;
	private bool activated = false;
	public void spawn() {
		if (!activated) {
			return;
		}
		Instantiate(prefabs[(int)Random.Range(0, 3)], transform.position, Quaternion.identity, transform.parent);
		Destroy(this.gameObject);
	}
	//public void OnTriggerEnter2D(Collider2D other) {
	//	if (!activated || other.tag != "BoneFragment") {
	//		return;
	//	}
	//	spawn();
	//}z
	public void activate() {
		activated = true;
	}

}
