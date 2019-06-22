using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButtonScript : MonoBehaviour
{
    Text DetailView;

    GameObject MissionButtonBar;

    Manager.Task task = new Manager.Task();


    void Start()
    {
        DetailView = GameObject.Find("Canvas/Details/Information/Text").GetComponent<Text>();
        
    }

    void Update()
    {
        

    }

    public void SetTask(Manager.Task t)
    {
        task = t;
    }

    public void OnClick()
    {
        DetailView.text = task.Name;
        Debug.Log(DetailView.text);
    }

    
}
