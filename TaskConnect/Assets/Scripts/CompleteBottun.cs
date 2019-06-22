using UnityEngine;
using UnityEngine.UI;

public class CompleteBottun : MonoBehaviour
{

    Button cpl;

    void Start()
    {
        cpl = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        cpl.interactable = false;
        Debug.Log("ボタンが押された");
    }
}
