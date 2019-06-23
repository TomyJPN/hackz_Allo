using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTaskButton : MonoBehaviour {
  Text descriptionText;

  Manager.Task task = new Manager.Task();
  GameObject detailView;

  QuestManager qm;

  void Start() {
    descriptionText = GameObject.Find("Canvas/Description/Text").GetComponent<Text>();
    qm = GameObject.Find("QuestManager").GetComponent<QuestManager>();
  }

  // Update is called once per frame
  void Update() {

  }


  public void SetTask(Manager.Task t) {
    task = t;
  }
  public void onDetailView() {
    descriptionText.text = task.Description + " 締切：" + task.Deadline.ToShortDateString();
    descriptionText.text +="\n攻撃力："+ (task.Difficulty * 25).ToString();
  }

  public void onEndTask() {
    qm.onPlayCutin(task.Name, task.Difficulty * 25);
    Manager.Instance.removeTask(task.GUID);
    Destroy(gameObject);
  }

}
