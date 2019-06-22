using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public int buttonnumber;
    public void OnClick()
    {
        string scene = SceneManager.GetActiveScene().name;
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
