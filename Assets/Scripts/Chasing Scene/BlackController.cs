using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackController : MonoBehaviour
{
	public AudioManager audioManager;
	private GameObject littleElephant;
	public bool isTop;
	private bool isSwitched = false;
	// Start is called before the first frame update
	void Start()
	{
		littleElephant = GameObject.Find("LittleElephant");
	}

	// Update is called once per frame
	void Update()
	{
		transform.localPosition = new Vector3(0, (isTop ? 1 : -1) * (littleElephant.transform.position.x - transform.position.x + 30f), 0);

		if (isTop) {
			if (littleElephant.transform.position.x - transform.position.x + 30f < 16f && !isSwitched) {
				audioManager.playClip(1);
				isSwitched = true;
			}
			if (littleElephant.transform.position.x - transform.position.x + 30f < 12f) {
				SceneManager.LoadScene(sceneName:"Elephant2");
			}
		}
	}
}
