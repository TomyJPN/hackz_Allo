﻿using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ゲーム起動中常に単一で存在し続けるマネージャー(使い方：Manager.Instance.関数() )
/// </summary>
public class Manager : SingletonMonoBehaviour<Manager> {

  public class Task {
    /// <summary>
    /// 一意のID
    /// </summary>
    public string GUID { get; set; }

    /// <summary>
    /// 1:"quest"，2:"mission"
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// タスク名（例："数学課題"）
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 細かい内容（例：教科書10p 問題1）
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 難易度（1,2,3）
    /// </summary>
    public int Difficulty { get; set; }

    /// <summary>
    /// 締め切り日
    /// </summary>
    public DateTime Deadline { get; set; }
  }

  private List<Task> taskList = new List<Task>();  //総合的に入れるリスト

  /// <summary>
  /// 新規のタスクをマネージャーへデータ追加します
  /// </summary>
  public void SetTask(int type,string name,string description,int difficulty,DateTime deadline) {
    Task newTask = new Task();
 
    newTask.GUID = Guid.NewGuid().ToString("N");
    newTask.Type = type;
    newTask.Name = name;
    newTask.Description = description;
    newTask.Difficulty = difficulty;
    newTask.Deadline = deadline;

    taskList.Add(newTask);
  }

  /// <summary>
  /// 指定タイプでまとまったタスクリストを取得します
  /// </summary>
  /// <param name="type">"quest"，"mission"どちらか</param>
  /// <returns></returns>
  public List<Task> GetTaskListForType(int type) {
    List<Task> returnTask = new List<Task>();

    for(int i = 0; i < taskList.Count; i++) {
      if (type == taskList[i].Type) {
        returnTask.Add(taskList[i]);
      }
    }

    return returnTask;
  }

  /// <summary>
  /// 全タスクを取得します
  /// </summary>
  /// <returns></returns>
  public List<Task> GetTaskAll() {
    return taskList;
  }

  /// <summary>
  /// タスクを指定GUIDから削除します
  /// </summary>
  public void removeTask(string GUID) {
    for (int i = 0; i < taskList.Count; i++) {
      if (GUID == taskList[i].GUID) {
        taskList.RemoveAt(i);
      }
    }
  }

}
