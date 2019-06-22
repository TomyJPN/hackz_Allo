using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public int buttonnumber;
    public Sprite trueimage;
    public Sprite falseimage;
    private Image _image;
    public bool OnClicked = false;
    public MainButtonController MainButtonController;
    
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void FalseButton()
    {
        _image.sprite = falseimage;
    }

    public void OnClick()
    {
        string scene = SceneManager.GetActiveScene().name;
        _image.sprite = trueimage;
        OnClicked = true;
        MainButtonController.ButtonClick(buttonnumber);
        switch (buttonnumber)
        {
            case 0:
                if (scene!="CharacterSettings")
                {
                    SceneManager.LoadScene("CharacterSettings");

                }
                break;
            case 1:
                if (scene!="Home")
                {
                    SceneManager.LoadScene("Home");
                }
                break;
            case 2:
                if (scene!="InputTask")
                {
                    SceneManager.LoadScene("InputTask");
                }
                break;
            case 3:
                if (scene!="Loot box")
                {
                    SceneManager.LoadScene("Loot box");
                }
                
                break;
            case 4:
                if (scene!="Mission")
                {
                    SceneManager.LoadScene("Mission");
                }
                break;
            case 5:
                if (scene!="quest")
                {
                    SceneManager.LoadScene("quest");
                }
                break;
        }
    }
}
