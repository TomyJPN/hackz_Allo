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
    public GameObject PopUpUI;
    public Text PopUptext;
    private DateTime date;
    private DataSetDateTime Data;

    public void OnClick()
    {
        if (HardToggle.isOn||NormalToggle.isOn||EasyToggle.isOn)
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


                                                         string strTime = Year.text+"/"+Month.text+"/"+Day.text;

                                                         if (DateTime.TryParse(strTime, out date)&&date>=DateTime.Today)
                                                         {
                                                             CreateTask();

                                                         }
                                                         else
                                                         {
                                                             PopUptext.text = "存在しない日付,もしくは過去の日付です    ";
                                                             PopUpUI.SetActive(true);
                                                             
                                                         }
                                                         
                                                            
                                                         
                                                         

                                                     }
                                                     else
                                                     {
                                                         PopUptext.text = "正確なタスクの締切日を記入して下さい";
                                                         PopUpUI.SetActive(true);

                                                     }
                                                 }
                                                 else
                                                 {
                                                     PopUptext.text = "正確なタスクの締切月を記入してください";
                                                     PopUpUI.SetActive(true);

                                                 }
                                             }
                                             else
                                             {
                                                 PopUptext.text = "タスクの締切年を記入して下さい";
                                                 PopUpUI.SetActive(true);

                                             }
                                         }
                                         else
                                         {
                                             if (MaxContinuation.text=="")
                                             {
                                                 CreateTask();
                                             }
                                             else
                                             {
                                                 PopUptext.text = "習慣づけたと考える日数を記入してください";
                                                 PopUpUI.SetActive(true);

                                             }
                                         }        
                                     }
                                     else
                                     {
                                         PopUptext.text = "習慣、タスクの選択をしてください";
                                         PopUpUI.SetActive(true);

                                     }
                                 }
                                 else
                                 {
                                     PopUptext.text = "タスクについての説明を記入してください";
                                     PopUpUI.SetActive(true);

                                 }
                             }
                             else
                             {
                                 PopUptext.text = "タスクのタイトルを設定してください";
                                 PopUpUI.SetActive(true);

                             }
        }
        else
        {
            PopUptext.text = "難易度を設定してください";
            PopUpUI.SetActive(true);
        }       
        
    }

    public void OnClickPopUp()
    {
        PopUpUI.SetActive(false);
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
            Manager.Instance.SetQuestTask(TitleName.text,Description.text,Difficulty,date);  //登録

        }
        else
        {
            type = 2;
            Manager.Instance.SetMissionTask(TitleName.text,Description.text,Difficulty,int.Parse(MaxContinuation.text));
        }

    }
    
}

