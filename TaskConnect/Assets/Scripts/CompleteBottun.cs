using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBottun : MonoBehaviour
{
    Text Continuation;
    //Button cpl;
    Manager.Task task = new Manager.Task();

    void Start()
    {
        //cpl = GetComponent<Button>();
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Text>();

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
        //cpl.interactable = false;
        //Continuation.text = (task.NowContinuation).ToString();
        Debug.Log("ボタンが押された");
    }
}
