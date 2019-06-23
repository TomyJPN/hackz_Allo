using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBottun : MonoBehaviour
{
    Slider Continuation;
    Text ContinuationInfo;
    MissionButtonScript mbs;

    void Start()
    {
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        ContinuationInfo = GameObject.Find("Canvas/ContinuationInfo/Text").GetComponent<Text>();
        mbs = transform.parent.parent.GetComponent<MissionButtonScript>();
        Debug.Log("取得確認："+transform.parent.parent.name);
        //float maxCont = Continuation.maxValue;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Click()
    {
        mbs.UpdateContinuation();
       
    }
}
