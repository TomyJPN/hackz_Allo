using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButtonScript : MonoBehaviour
{
    Text DetailView;
    Text ContinuationInfo;
    Slider Continuation;
    GameObject MissionButtonBar;
    public GameObject btn;

    Manager.Task task = new Manager.Task();


    void Start()
    {
        DetailView = GameObject.Find("Canvas/Details/Information/Text").GetComponent<Text>();
        Continuation = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        ContinuationInfo = GameObject.Find("Canvas/Details/ContinuationInfo/Text").GetComponent<Text>();

        //float maxCont = 100f;
        //Continuation.maxValue = maxCont;
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
        DetailView.text = task.Description;
        Continuation.maxValue = task.MaxContinuation;
        Continuation.value = task.NowContinuation;
        ContinuationInfo.text = Continuation.value.ToString() + "/" + Continuation.maxValue.ToString();
        btn.SetActive(false);
        //GameObject.Find("Canvas/Scroll View/Viewport/Content/MissionBarButton/MissionBar").GetComponent<Button>().interactable = false;
        //GameObject btn = GameObject.Find("Button");
        //Debug.Log(btn);
        //btn.GetComponent<Button>().interactable = false;
    }

    public void UpdateContinuation()
    {
        //DetailView.text = task.Description;
        Continuation.value = task.NowContinuation + 1;      //1は仮入れ
        Continuation.maxValue = task.MaxContinuation;   //7は仮入れ
        ContinuationInfo.text = Continuation.value.ToString() + "/" + Continuation.maxValue.ToString();
        Manager.Instance.setNowContinuationByGUID((int)Continuation.value, task.GUID);
    }
    
}
