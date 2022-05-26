using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombController : MonoBehaviour
{
    public GameObject comb;
    public Animator combAnim;
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
        combAnim.SetBool("isComb", true);
        Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
        comb.transform.position = currentWorldPosition;
    }
    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        combAnim.SetBool("isComb", false);
    }
}
