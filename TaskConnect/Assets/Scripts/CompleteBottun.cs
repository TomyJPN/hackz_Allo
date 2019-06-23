﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBottun : MonoBehaviour
{
    Slider Continuation;
    Text ContinuationInfo;

    Manager.Task task = new Manager.Task();

    void Start()
    {
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        ContinuationInfo = GameObject.Find("Canvas/ContinuationInfo/Text").GetComponent<Text>();

        //float maxCont = Continuation.maxValue;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMissionTask(Manager.Task t)
    {
        task = t;
    }

    public void Click()
    {
        //DetailView.text = task.Description;
        Continuation.value = task.NowContinuation + 1;  //1は仮入れ
        Continuation.maxValue = task.MaxContinuation + 7;//7は仮入れ
        ContinuationInfo.text = Continuation.value.ToString() + "/" + Continuation.maxValue.ToString();
    }
}
