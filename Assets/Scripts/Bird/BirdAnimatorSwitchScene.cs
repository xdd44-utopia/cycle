using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimatorSwitchScene : MonoBehaviour
{
	public BirdSubSceneSwitch scene;
	public void switchScene() {
		scene.nextScene();
	}
}
