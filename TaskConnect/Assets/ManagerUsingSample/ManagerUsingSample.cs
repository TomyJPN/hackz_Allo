using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 使い方解説
/// </summary>
public class ManagerUsingSample : MonoBehaviour {

  void Start() {
    //このスクリプト内で新規に作るタスクの宣言
    Manager.Task myTask1 = new Manager.Task();

    int type = 1; //quest
    string name = "課題";
    string description = "教科書10ページ";
    int difficully = 1;
    int maxContinuation=5;
    DateTime deadLine= new DateTime(2000, 8, 1);
    Manager.Instance.SetTask(type,name,description,difficully,deadLine,maxContinuation);  //登録

    type = 1; //quest
    name = "掃除";
    description = "自分の部屋";
    difficully = 1;
    maxContinuation = 6;
    deadLine = new DateTime(2000, 8, 2);
    Manager.Instance.SetTask(type, name, description, difficully, deadLine,maxContinuation); //登録


    //取得
    List<Manager.Task> list = new List<Manager.Task>();
    list = Manager.Instance.GetTaskAll();
    for(int i = 0; i < list.Count; i++) {
      Debug.Log("タスク[" + i + "] 名前:" + list[i].Name + ", 説明:" + list[i].Description + ", GUID" + list[i].GUID);
    }
  }

  void Update() {

  }
}
