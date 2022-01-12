using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleElephantController : MonoBehaviour
{
	private GameObject elephant;
	private Animator anim;
	private float life;
	private const float decrease = 0.025f;
	private const float increase = 0.4f;
	private const float maxSpeed = 0.8f;
	private const float minSpeed = 0.4f;
	private float speed = 1;
	void Start() {
		life = 1;
		elephant = GameObject.Find("Elephant");
		speed = SceneController.speed;
		anim = GetComponent<Animator>();
	}
	void Update() {
		life -= decrease * Time.deltaTime;
		life = life > minSpeed ? life : minSpeed;
		anim.SetFloat("Speed", life);
		GetComponent<SpriteRenderer>().color = new Color(life, life, life, 1);
		if (Mathf.Abs(elephant.transform.position.x - 4f - transform.position.x) < 0.5f) {
			life += increase * Time.deltaTime;
			life = life < maxSpeed ? life : maxSpeed;
		}
		else {
			transform.position += new Vector3(life * speed * Time.deltaTime, 0, 0);
		}
	}

}
