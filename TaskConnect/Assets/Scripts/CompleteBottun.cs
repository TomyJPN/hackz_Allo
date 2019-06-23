using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBottun : MonoBehaviour
{
    Slider Continuation;
    //Text DetailView;

    Manager.Task task = new Manager.Task();

    void Start()
    {
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        //DetailView = GameObject.Find("Canvas/Details/Information/Text").GetComponent<Text>();

        float maxCont = 100f;
        

        Continuation.maxValue = maxCont;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settask(Manager.Task t)
    {
        task = t;
    }

    public void Click()
    {
        //DetailView.text = task.Description;
        Continuation.value = task.NowContinuation + 10;
        Debug.Log("ボタンが押された");
    }
}
