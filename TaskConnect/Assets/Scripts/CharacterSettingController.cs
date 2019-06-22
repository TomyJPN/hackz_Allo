using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSettingController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nametext;
    public Text Flavortext;
    public Image []image =new Image[5];
    public Sprite []sprite =new Sprite[6];
    public bool[] enabled = new bool[5]{true,true,true,true,true};
    public bool[] clicked=new bool[5]{false,false,false,false,false};
    private int[] wait = new int[5]{0,0,0,0,0};
    public void RobeOnClick()
    {
        SpriteChange(0);
    }

    public void StickOnClick()
    {
        SpriteChange(1);

    }

    public void HatOnClick()
    {
        SpriteChange(2);

    }

    public void ShoeOnClick()
    {
        SpriteChange(3);

    }

    public void RingOnClick()
    {
        SpriteChange(4);

    }

    private void WaitReset(int a)
    {
        for (int i = 0; i < 5; i++)
        {
            if (a!=i)
            {
                wait[i] = 0;
            }
        }
    }

    private void SpriteChange(int i)
    {
        if (clicked[i])
        {
            if (wait[i]==1)
            {
                nametext.text = "";
                Flavortext.text = "";

                image[i].sprite = sprite[5];
                WaitReset(5);
                clicked[i] = false;
            }
            else
            {
                if (i==0)
                {
                    nametext.text = "魔法使いのローブ";
                    Flavortext.text = "偉大な魔法使いのみ着ることができるローブ。\n防御力が向上する";
                }else if(i==1)
                {
                    nametext.text = "天使の杖";
                    Flavortext.text = "天使の力を借りて、攻撃することができる。\n攻撃力が向上する";
                }else if (i==2)
                {
                    nametext.text = "魔法使いの帽子";
                    Flavortext.text = "魔法使いにとって大事な頭を守ってくれる帽子。\n防御力が向上する";
                }else if (i==3)
                {
                    nametext.text = "丈夫な靴";
                    Flavortext.text = "エルフによって仕立てられた、ドラゴンの炎からも守ってくれる靴。\n防御力が向上する";
                }else if (i==4)
                {
                    nametext.text = "妖精の指輪";
                    Flavortext.text = "妖精と契約することにより、身体能力を強化することができる。\nHPが向上する";
                }
                wait[i] = 1;
                WaitReset(i);

            }
            
        }
        else if (enabled[i])
        {
            image[i].sprite = sprite[i];
            clicked[i] = true;
        }
    }
}
