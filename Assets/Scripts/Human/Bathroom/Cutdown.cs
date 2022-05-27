using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutdown : MonoBehaviour
{
    public int goal;
    private HumanSubSceneSwitch controller;
    public int beforeSceneNum;
    public int nextSceneNum;
    private int count;
    public float totalTime;
    private float acc;
    private Transform mask;
    private Vector3 maskCenterPos;
    // Start is called before the first frame update
    void Start()
    {
        acc = 0;
        count = 0;
        mask = this.gameObject.transform.GetChild(1);
        maskCenterPos = mask.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        acc += Time.deltaTime;
        Debug.Log(acc);
        if (controller == null)
        {
            controller = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
        }
        if (count==goal)
        {
            controller.switchScene(nextSceneNum);
        }
        if (totalTime < acc)
        {
            controller.switchScene(beforeSceneNum);
        }
        else
        {
            mask.transform.localScale = new Vector3(1-acc / totalTime, 1, 1);
            mask.transform.localPosition = new Vector3(maskCenterPos.x - 5.5f * (acc / totalTime), maskCenterPos.y, maskCenterPos.z);
        }

    }
    public void addCount()
    {
        count += 1;
    }
}
