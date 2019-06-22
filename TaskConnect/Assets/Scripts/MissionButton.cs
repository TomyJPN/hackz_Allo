using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissionButton : MonoBehaviour
{
    //ミッション画面に表示されるボタンのプレハブ
    [SerializeField]
    GameObject MissionBarButton;

    //const int BUTTON_COUNT = 10;

    void setTestData()
    {
        int type = 1; //quest
        string name = "課題";
        string description = "教科書10ページ";
        int difficully = 1;
        int maxContinuation = 5;
        DateTime deadLine = new DateTime(2000, 8, 1);
        Manager.Instance.SetTask(type, name, description, difficully, deadLine, maxContinuation);  //登録

        type = 1; //quest
        name = "掃除";
        description = "自分の部屋";
        difficully = 1;
        maxContinuation = 6;
        deadLine = new DateTime(2000, 8, 2);
        Manager.Instance.SetTask(type, name, description, difficully, deadLine, maxContinuation); //登録

    }

    void Start()
    {
        setTestData();

        //ボタン並べる場所の取得
        RectTransform content = GameObject.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();

        List<Manager.Task> list = new List<Manager.Task>();
        list = Manager.Instance.GetTaskAll();
        
        int BUTTON_COUNT = list.Count;

        //Contentの高さ設定
        //(ボタンの高さ＋ボタンの間隔)×ボタン数
        //float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
        //float btnHeight = MissionBarButton.GetComponent<LayoutElement>().preferredHeight;
        //content.sizeDelta = new Vector2(0, (btnHeight + btnSpace) * BUTTON_COUNT);
        for(int i = 0; i < BUTTON_COUNT; i++)
        {
            int no = i;
            //ボタン生成
            GameObject btn = (GameObject)Instantiate(MissionBarButton);
            //ボタンをContentの子に設定
            btn.transform.SetParent(content, false);
            //ボタンのテキスト変更
            btn.transform.GetComponentInChildren<Text>().text = list[i].Name;
            //ボタンのクリックイベント登録
            //btn.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));
        }
    }

    public void OnClick(int no)
    {
        Debug.Log(no);
    }
}
