using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle QuestToggle;
    public Toggle MissionToggle;
    public Toggle HardToggle;
    public Toggle NormalToggle;
    public Toggle EasyToggle;
    public InputField TitleName;
    public InputField Description;
    public InputField Year;
    public InputField Month;
    public InputField Day;
    public InputField MaxContinuation;
    public GameObject QuestUI;

    public GameObject MissionUI;

    public void OnClick()
    {if (HardToggle.isOn||NormalToggle.isOn||EasyToggle.isOn)
                 {
                     if (TitleName.text!="")
                     {
                         if (Description.text!="")
                         {
                             if (QuestToggle.isOn||MissionToggle.isOn)
                             {
                                 if (QuestToggle.isOn)
                                 {
                                     if (Year.text!="")
                                     {
                                         if (Month.text!="")
                                         {
                                             if (Day.text!="")
                                             {
                                                 CreateTask();
                                             }
                                         }
                                     }
                                 }
                                 else
                                 {
                                     if (MaxContinuation.text=="")
                                     {
                                         CreateTask();
                                     }
                                 }            
                             }
                         }
                     }
                 }
        
    }

    public void ToggleChange()
    {
        if (QuestToggle.isOn)
        {
            QuestUI.SetActive(true);
        }
        else
        {
            QuestUI.SetActive(false);
        }

        if (MissionToggle.isOn)
        {
            MissionUI.SetActive(true);
        }
        else
        {
            MissionUI.SetActive(false);
        }
    }

    private void CreateTask()
    {
        int type = 0, Difficulty = 0;
        Manager.Task myTask1 = new Manager.Task();
        DateTime data;

        if (HardToggle.isOn)
        {
            Difficulty = 3;
        }else if (NormalToggle.isOn)
        {
            Difficulty = 2;
        }
        else
        {
            Difficulty = 1;
        }
        if (QuestToggle.isOn)
        {
            type = 1;
            data = new DateTime(int.Parse(Year.text),int.Parse(Month.text),int.Parse(Day.text));
            Manager.Instance.SetQuestTask(TitleName.text,Description.text,Difficulty,data);  //登録

        }
        else
        {
            type = 2;
            Manager.Instance.SetMissionTask(TitleName.text,Description.text,Difficulty,int.Parse(MaxContinuation.text));
        }

    }
    
}

