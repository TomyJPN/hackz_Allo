using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButtonScript : MonoBehaviour
{
    Text DetailView;
    //Text ContinuationInfo;
    //Slider Continuation;
    GameObject MissionButtonBar;

    Manager.Task task = new Manager.Task();


    void Start()
    {
        DetailView = GameObject.Find("Canvas/Details/Information/Text").GetComponent<Text>();
        //Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        //ContinuationInfo = GameObject.Find("Canvas/ContinuationInfo/Text").GetComponent<Text>();

        //float maxCont = 100f;
        //Continuation.maxValue = maxCont;
    }

    void Update()
    {
        
    }

    public void SetMissionTask(Manager.Task t)
    {
        task = t;
    }

    public void OnClick()
    {
        DetailView.text = task.Description;
        //Continuation.value = task.NowContinuation + 10;
        //ContinuationInfo.text = Continuation.value.ToString() + "/" + Continuation.maxValue.ToString();
    }

    
}
