using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestManager : MonoBehaviour {
  [SerializeField]
  GameObject taskPrefab;

  [SerializeField]
  GameObject content;

  [SerializeField]
  GameObject cutInView;

  [SerializeField]
  GameObject Tasks;

  [SerializeField]
  GameObject Description;

  [SerializeField]
  Text cutinText;

  List<Manager.Task> taskList;

  void Start() {
    setSampleData();

    taskList = new List<Manager.Task>();
    taskList = Manager.Instance.GetTaskListForType(1);

    for(int i = 0; i < taskList.Count; i++) {
      GameObject obj = Instantiate(taskPrefab);
      obj.transform.parent = content.transform;
      obj.transform.localScale = obj.transform.lossyScale;  //原寸に
      QuestTaskButton qtb = obj.GetComponent<QuestTaskButton>();
      qtb.SetTask(taskList[i]);
      obj.transform.Find("Text").GetComponent<Text>().text = taskList[i].Name;
    }
  }

  void Update() {

  }

  void setSampleData() {
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

  public void onPlayCutin(string text) {
    Tasks.SetActive(false);
    Description.SetActive(false);
    cutInView.SetActive(true);
    cutinText.text = text;
    Invoke("offCutin", 2.1f);
  }

  void offCutin() {
    Tasks.SetActive(true);
    Description.SetActive(true);
    cutInView.SetActive(false);
  }
}
