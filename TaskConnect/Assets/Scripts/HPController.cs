using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HP;
    private Manager.GameData data =new Manager.GameData();
    private void Start()
    {
        Manager.Task myTask1 = new Manager.Task();
        data = Manager.Instance.GetGameDataAll();
        HP.fillAmount=data.MyHP;
    }
}
