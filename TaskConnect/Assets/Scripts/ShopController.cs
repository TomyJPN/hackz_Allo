using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject Popup;

    public void Start()
    {
        Manager.Task myTask1 = new Manager.Task();
       Manager.GameData data =new Manager.GameData();
       data = Manager.Instance.GetGameDataAll();
       text.text = ""+data.Coin;
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
        switch (k)
        {
            case 0:
                if (Manager.Instance.UseCoin(100))
                {
                    Popup.SetActive(true);
                }
                else
                {
                    Manager.Instance.SetIsWeponListByIndex(k,true);
                }
                break;
            case 1:
                if (Manager.Instance.UseCoin(100))
                {
                    Popup.SetActive(true);
                }
                else
                {
                    Manager.Instance.SetIsWeponListByIndex(k,true);

                }
                break;
            case 2:
                if (Manager.Instance.UseCoin(100))
                {
                    Popup.SetActive(true);
                }
                else
                {
                    Manager.Instance.SetIsWeponListByIndex(k,true);

                }
                break;
            case 3:
                if (Manager.Instance.UseCoin(100))
                {
                    Popup.SetActive(true);
                }
                else
                {
                    Manager.Instance.SetIsWeponListByIndex(k,true);

                }
                break;
            case 4 :
                if (Manager.Instance.UseCoin(100))
                {
                    Popup.SetActive(true);
                }
                else
                {
                    Manager.Instance.SetIsWeponListByIndex(k,true);

                }
                break;
        }
    }
    
}
