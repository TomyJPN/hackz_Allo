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

  [SerializeField]
  GameObject attackEffect;
  [SerializeField]
  GameObject explosionEffect;

  List<Manager.Task> taskList;

  [SerializeField]
  Image enemyHP;
  [SerializeField]
  Image myHP;
  [SerializeField]
  GameObject HPView;
  [SerializeField]
  Animator enemyAnimator;
  int attackDamage;
  [SerializeField]
  Animator clearAnimator;

  GameObject nav;

  Manager.GameData gameData = new Manager.GameData();

  void Start() {
    nav = GameObject.Find("CanvasNav").gameObject;
    nav.SetActive(false);

    //setSampleData();

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

    gameData = Manager.Instance.GetGameDataAll();
    myHP.fillAmount = gameData.MyHP;
    Debug.Log("HP:" + gameData.MyHP);
    enemyHP.fillAmount = gameData.EnemyHP;
  }

  void Update() {

  }

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

  public void onPlayCutin(string text , int damage) {
    attackDamage = damage;
    Tasks.SetActive(false);
    Description.SetActive(false);
    cutInView.SetActive(true);
    HPView.SetActive(false);
    cutinText.text = text;
    Invoke("offCutin", 2.1f);
    Invoke("damage",4.6f);
    Invoke("ON_UI", 5.5f);
  }

  void offCutin() {
    cutInView.SetActive(false);
    HPView.SetActive(true);
    attackEffect.SetActive(true);
  }

  void damage() {
    Instantiate(explosionEffect,new Vector3(4.45f,0f,10.43f),Quaternion.identity);
    attackEffect.SetActive(false);
    gameData.EnemyHP -= attackDamage*0.01f;
    enemyHP.fillAmount = gameData.EnemyHP;
    iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
    if (gameData.EnemyHP <= 0.01) {
      enemyAnimator.SetTrigger("down");
      Invoke("clear", 2.3f);
    }
  }

  void ON_UI() {
    Tasks.SetActive(true);
    Description.SetActive(true);
  }

  void clear() {
    clearAnimator.SetTrigger("clear");
    Invoke("goTitle", 3f);
  }

  void goTitle() {
    nav.SetActive(true);
    UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
  }
}
