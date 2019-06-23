using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    Text ContinuationInfo;
    Slider Continuation;

    Manager.Task task = new Manager.Task();

    void Start()
    {
        ContinuationInfo = GameObject.Find("Canvas/ContinuationInfo/Text").GetComponent<Text>();
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();

        float maxCont = 100f;
        Continuation.maxValue = maxCont;
    }

    void Update()
    {
        
    }

    public void Settask(Manager.Task t)
    {
        task = t;
    }

    public void OnClick()
    {
        Continuation.value = task.NowContinuation + 10;
        ContinuationInfo.text = Continuation.value.ToString() + "/" + Continuation.maxValue.ToString();
    }
}
