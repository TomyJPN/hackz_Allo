using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject Popup;

    public void Start()
    {
        
    }
    public void RobeOnClick()
    {
        Buyitem(0);
    }

    public void StickOnClick()
    {
        Buyitem(1);

    }

    public void HatOnClick()
    {
        Buyitem(2);

    }

    public void ShoeOnClick()
    {
        Buyitem(3);

    }

    public void RingOnClick()
    {
        Buyitem(4);

    }

    public void PopUpOnClick()
    {
        Popup.SetActive(false);
    }

    private void Buyitem(int k)
    {
            
    }
    
}
