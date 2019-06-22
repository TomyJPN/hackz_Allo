using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public ButtonController []Button=new ButtonController[6];



    // Update is called once per frame
    public void ButtonClick(int number)
    {
        for (int i = 0; i < 6; i++)
        {
            if (Button[i].OnClicked&&number!=i)
            {
               Button[i].FalseButton();
            }
        }
    }
}
