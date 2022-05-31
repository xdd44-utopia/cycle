using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelTask2 : MonoBehaviour
{
	public Animator scene;
	public float[] yPos;
	public Transform[] blues;
	public Transform[] blacks;
	private int[] blueCur = new int[5]{2, 2, 2, 2, 2};
	private int[] blackCur = new int[5]{1, 1, 1, 1, 1};
	private int[] blueAns = new int[5]{1, 2, 2, 3, 2};
	private int[] blackAns = new int[5]{0, 0, 1, 1, 1};
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (
			blueCur[0] == blueAns[0] && blackCur[0] == blackAns[0] &&
			blueCur[1] == blueAns[1] && blackCur[1] == blackAns[1] &&
			blueCur[2] == blueAns[2] && blackCur[2] == blackAns[2] &&
			blueCur[3] == blueAns[3] && blackCur[3] == blackAns[3] &&
			blueCur[4] == blueAns[4] && blackCur[4] == blackAns[4]
		) {
			scene.SetTrigger("Trigger");
			Destroy(this);
		}
		for (int i=0;i<5;i++) {
			blueCur[i] = blueCur[i] == -1 ? 3 : blueCur[i];
			blueCur[i] = blueCur[i] == 4 ? 0 : blueCur[i];
			blackCur[i] = blackCur[i] == -1 ? 3 : blackCur[i];
			blackCur[i] = blackCur[i] == 4 ? 0 : blackCur[i];
			blues[i].localPosition = new Vector3(blues[i].localPosition.x, yPos[blueCur[i]] + 0.15f, 0);
			blacks[i].localPosition = new Vector3(blacks[i].localPosition.x, yPos[blackCur[i]] - 0.15f, 0);
		}
	}

	public void switchPos(bool isBlue, int i) {
		if (isBlue) {
			blueCur[i]++;
			blackCur[i]--;
		}
		else {
			if (i > 0) {
				blackCur[i - 1]++;
			}
			if (i < 4) {
				blackCur[i + 1]++;
			}
		}
	}
}
