using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttractingController : MonoBehaviour
{
	private AttractableController target;
	public int automateTime;
	public bool manualActivate;
	private float timer = 0;
	// Start is called before the first frame update
	protected virtual void Start()
	{
		
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		if (automateTime > 0) {
			timer += Time.deltaTime;
			if (timer > automateTime) {
				activate();
				automateTime = -1;
			}
		}
		if (!manualActivate) {
			activate();
		}
	}

	protected virtual void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		activate();
	}

	public virtual void activate() {
		target.beAttracted(transform.position);
	}

	public void setTarget(AttractableController tar) {
		target = tar;
	}


}
