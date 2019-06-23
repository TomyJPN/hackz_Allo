using System.Collections.Generic;
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
    /// 難易度（1,2,3）3が難しい
    /// </summary>
    public int Difficulty { get; set; }

    /// <summary>
    /// 締め切り日
    /// </summary>
    public DateTime Deadline { get; set; }

    /// <summary>
    /// 継続日の進捗(ミッション用)
    /// </summary>
    public int NowContinuation { get; set; }

    /// <summary>
    /// 目標継続日(ミッション用)
    /// </summary>
    public int MaxContinuation { get; set; }
  }

  public class GameData {
    /// <summary>
    /// 所持コイン数
    /// </summary>
    public int Coin { get; set; }

    /// <summary>
    /// UnityちゃんのHP(割合)
    /// </summary>
    public float MyHP { get; set; }

    /// <summary>
    /// 敵のHP（割合）
    /// </summary>
    public float EnemyHP { get; set; }

    /// <summary>
    /// 攻撃力
    /// </summary>
    public int Attack { get; set; }

    /// <summary>
    /// 防御力S
    /// </summary>
    public int Deffence { get; set; }

    /// <summary>
    /// 武器を所持しているかのリスト
    /// </summary>
    public List<bool> isWeaponGetting { get; set; }
  }

  private List<Task> taskList = new List<Task>();  //総合的に入れるリスト

  public GameData gameData = new GameData();       //保存するゲームデータ

<<<<<<< HEAD
  void setSampleData() {
    int type = 1; //quest
    string name = "課題";
    string description = "教科書10ページ";
    int difficully = 3;
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

    type = 1; //quest
    name = "プリントもってくる";
    description = "学校の";
    difficully = 2;
    maxContinuation = 6;
    deadLine = new DateTime(2000, 8, 2);
    Manager.Instance.SetTask(type, name, description, difficully, deadLine, maxContinuation); //登録
  }

  private void Awake() {
    if (this != Instance) {
      Destroy(this);
      return;
    }

    DontDestroyOnLoad(this.gameObject);

=======
  private void Awake() {
>>>>>>> f7708f59036d2534a85c2be46c79d5ba8e8c9b06
    gameData.MyHP = 1;
    gameData.EnemyHP = 1;
    gameData.Attack = 1;
    gameData.Deffence = 1;
<<<<<<< HEAD
    gameData.isWeaponGetting = new List<bool>();
=======
        gameData.isWeaponGetting = new List<bool>();
>>>>>>> f7708f59036d2534a85c2be46c79d5ba8e8c9b06
    for(int i = 0; i < 5; i++) {
      bool b=false;
      gameData.isWeaponGetting.Add(b);
    }

    setSampleData();
  }

  /// <summary>
  /// 廃止
  /// </summary>
  public void SetTask(int type,string name,string description,int difficulty,DateTime deadline , int maxContinuation) {
    Task newTask = new Task();
 
    newTask.GUID = Guid.NewGuid().ToString("N");
    newTask.Type = type;
    newTask.Name = name;
    newTask.Description = description;
    newTask.Difficulty = difficulty;
    newTask.Deadline = deadline;
    newTask.MaxContinuation = maxContinuation;
    newTask.NowContinuation = 0;

    taskList.Add(newTask);
  }

  /// <summary>
  /// 新規のクエスト用タスクをマネージャーへデータ追加します
  /// </summary>
  public void SetQuestTask( string name, string description, int difficulty, DateTime deadline) {
    Task newTask = new Task();

    newTask.GUID = Guid.NewGuid().ToString("N");
    newTask.Type = 1;
    newTask.Name = name;
    newTask.Description = description;
    newTask.Difficulty = difficulty;
    newTask.Deadline = deadline;
    newTask.MaxContinuation = 0;
    newTask.NowContinuation = 0;

    taskList.Add(newTask);
  }

  /// <summary>
  /// 新規のデイリーミッション用タスクをマネージャーへデータ追加します
  /// </summary>
  public void SetMissionTask(string name, string description, int difficulty, int maxContinuation) {
    Task newTask = new Task();

    newTask.GUID = Guid.NewGuid().ToString("N");
    newTask.Type = 2;
    newTask.Name = name;
    newTask.Description = description;
    newTask.Difficulty = difficulty;
    newTask.Deadline = new DateTime(1, 1, 1) ;
    newTask.MaxContinuation = maxContinuation;
    newTask.NowContinuation = 0;

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
  /// タスクを指定GUIDを使って削除します
  /// </summary>
  public void removeTask(string GUID) {
    for (int i = 0; i < taskList.Count; i++) {
      if (GUID == taskList[i].GUID) {
        taskList.RemoveAt(i);
      }
    }
  }

  /// <summary>
  /// タスクの継続日数をGUIDで更新します
  /// </summary>
  /// <param name="nowContinuation"></param>
  /// <param name="GUID"></param>
  public void setNowContinuationByGUID(int nowContinuation , string GUID) {
    for (int i = 0; i < taskList.Count; i++) {
      if (GUID == taskList[i].GUID) {
        taskList[i].NowContinuation = nowContinuation;
      }
    }
  }

  /// <summary>
  /// コインの増減（マイナスだと消費し足りない場合falseを返す）
  /// </summary>
  /// <param name="n"></param>
  public bool UseCoin(int n) {
    if (gameData.Coin + n >= 0) {
      gameData.Coin += n;
      return true;
    }
    else {
      return false;
    }
  }

  /// <summary>
  /// 装備を持っているかのリストを取得します
  /// </summary>
  /// <returns></returns>
  public List<bool> GetIsWeaponList() {
    return gameData.isWeaponGetting;
  }

  /// <summary>
  /// 指定インデックス番号の武器の所持非所持を設定
  /// </summary>
  /// <param name="index">リストの要素番号</param>
  /// <param name="boolean">持ってるか持ってないか</param>
  public void SetIsWeponListByIndex(int index , bool boolean) {
    gameData.isWeaponGetting[index] = boolean;
  }

  /// <summary>
  /// ゲームデータを丸ごと取得
  /// </summary>
  /// <returns></returns>
  public GameData GetGameDataAll() {
    return gameData;
  }
}
