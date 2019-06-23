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

    void Start()
    {

        //ボタン並べる場所の取得
        RectTransform content = GameObject.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();

        List<Manager.Task> list = new List<Manager.Task>();
        //list = Manager.Instance.GetTaskAll();
        list = Manager.Instance.GetTaskListForType(2);

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

            MissionButtonScript mbs = btn.GetComponent<MissionButtonScript>();
            mbs.SetTask(list[i]);

        }
    }

    public void Click(int no)
    {
        Debug.Log(no);
    }
}
