using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrushController : MonoBehaviour
{
	public Animator humanAnim;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnMouseDrag()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		humanAnim.SetBool("isBrush", true);
	}
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		humanAnim.SetBool("isBrush", false);
	}
}
