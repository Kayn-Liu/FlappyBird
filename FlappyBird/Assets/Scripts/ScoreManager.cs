using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**************************************************************************
Mount: Score 
Function: In charge of getting the proper font of the score and 
displaying the score as well
**************************************************************************/
public class ScoreManager : MonoBehaviour
{
    //--------------------------------------------------
    //Private Variables Definition
    Sprite[] fonts;
    Image unit;
    Image ten;

    //--------------------------------------------------
    //Unity Cycle
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        GameObject unit2 = GameObject.Find("unit2");
        GameObject ten2 = GameObject.Find("ten2");
        if (unit2 != null && ten2 != null)
        {
            int score = GameManager.score;
            if (score <= 9)
            {
                ten2.GetComponent<Image>().sprite = fonts[0];
                unit2.GetComponent<Image>().sprite = fonts[score];
            }
            else
            {
                ten2.GetComponent<Image>().sprite = fonts[score / 10];
                unit2.GetComponent<Image>().sprite = fonts[score % 10];
            }
        }

    }

    void Update()
    {
        int score = GameManager.score;
        if (ten != null & unit != null)
        {
            if (score <= 9)
            {
                ten.sprite = fonts[0];
                unit.sprite = fonts[score];
            }
            else
            {
                ten.sprite = fonts[score / 10];
                unit.sprite = fonts[score % 10];
            }
        }

    }

    //--------------------------------------------------
    //Methods Definition
    void Init()
    {
        fonts = new Sprite[10];
        for (int i = 0; i <= 9; i++)
        {
            string path = "Arts/font_" + i.ToString();
            fonts[i] = Resources.Load<Sprite>(path);
        }

        unit = GameObject.Find("unit").GetComponent<Image>();
        ten = GameObject.Find("ten").GetComponent<Image>();
    }
}
