using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBar : MonoBehaviour
{
    Slider CountSlider;
    GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("Button");
        CountSlider = GetComponent<Slider>();

        float maxCount = 100f;
        float nowConut = 0f;

        CountSlider.maxValue = maxCount;
        CountSlider.value = nowConut;

    }

    // Update is called once per frame
    void Update()
    {
        btn.GetComponent<CompleteBottun>().Click();
        
    }
}
