using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTaskButton : MonoBehaviour {
  Text descriptionText;

  Manager.Task task = new Manager.Task();
  GameObject detailView;

  void Start() {
    descriptionText = GameObject.Find("Canvas/Description/Text").GetComponent<Text>();
  }

  // Update is called once per frame
  void Update() {

  }


  public void SetTask(Manager.Task t) {
    task = t;
  }
  public void onDetailView() {
    descriptionText.text = task.Name + "\n" + task.Description + ", " + task.Deadline.ToShortDateString();
  }
}
