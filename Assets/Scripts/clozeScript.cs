using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class clozeScript : MonoBehaviour
{

    public MinigameController controller;

    public TextMeshProUGUI output;

    public Color redColor;

    public Color greenColor;

    private int tries = 0;


    public MinigameAudio audio;

    public enum answer
        {
            none,
            wrong,
            rigth
        }


    // dropdown_1
    private int index_1;

    public TMP_Dropdown Dropdown_1;

    private answer answer_1;


    // dropdown_2
    private int index_2;

    public TMP_Dropdown Dropdown_2;

    private answer answer_2;


    // dropdown_3
    private int index_3;

    public TMP_Dropdown Dropdown_3;

    private answer answer_3;


    // dropdown_4
    private int index_4;

    public TMP_Dropdown Dropdown_4;

    private answer answer_4;


    // dropdown_5
    private int index_5;

    public TMP_Dropdown Dropdown_5;

    private answer answer_5;




    // get value from dropbox_1
    public void getValue_1(int indexValue_1)
    {
        this.index_1 = indexValue_1;
    }

    // get value from dropbox_2
    public void getValue_2(int indexValue_2)
    {
        this.index_2 = indexValue_2;
    }

    // get value from dropbox_3
    public void getValue_3(int indexValue_3)
    {
        this.index_3 = indexValue_3;
    }

    // get value from dropbox_4
    public void getValue_4(int indexValue_4)
    {
        this.index_4 = indexValue_4;
    }

    // get value from dropbox_5
    public void getValue_5(int indexValue_5)
    {
        this.index_5 = indexValue_5;
    }


    // OnClick button, all Dropboxes are checked if right or wrong
    public void confirm()
    {
        Debug.Log(index_1 + "+" + index_2 + "+" + index_3 + "+" + index_4 + "+" + index_5);

        //dropbox_1 to enum, right index_1 = 2
        if (index_1 == 0)
        {
            answer_1 = answer.none;
        }
        else if (index_1 == 2)
        {
            answer_1 = answer.rigth;
        }else
        {
            answer_1 = answer.wrong;
        }

        //dropbox_2 to enum, rigth index_2 = 1
        if (index_2 == 0)
        {
            answer_2 = answer.none;
        }
        else if (index_2 == 2)
        {
            answer_2 = answer.rigth;
        }
        else
        {
            answer_2 = answer.wrong;
        }

        //dropbox_3 to enum, rigth index_3 = 3
        if (index_3 == 0)
        {
            answer_3 = answer.none;
        }
        else if (index_3 == 3)
        {
            answer_3 = answer.rigth;
        }
        else
        {
            answer_3 = answer.wrong;
        }

        //dropbox_4 to enum, rigth index_4 = 1
        if (index_4 == 0)
        {
            answer_4 = answer.none;
        }
        else if (index_4 == 1)
        {
            answer_4 = answer.rigth;
        }
        else
        {
            answer_4 = answer.wrong;
        }

        //dropbox_5 to enum, rigth index_5 = 3
        if (index_5 == 0)
        {
            answer_5 = answer.none;
        }
        else if (index_5 == 5)
        {
            answer_5 = answer.rigth;
        }
        else
        {
            answer_5 = answer.wrong;
        }


        Debug.Log(answer_1 + "+" + answer_2 + "+" + answer_3 + "+" + answer_4 + "+" + answer_5);

        //nothing filled in
        if (index_1 == 0 || index_2 == 0 || index_3 == 0 || index_4 == 0 || index_5 == 0)
        {
            output.text = "Bitte wähle die Antworten aus!";
        }


        //checks if all answers are rigth
        else if (answer_1 == answer.rigth && answer_2 == answer.rigth && answer_3 == answer.rigth
                && answer_4 == answer.rigth && answer_5 == answer.rigth)
        {
            output.text = "Super. Das ist richtig!";
            reaction_1(answer_1, Dropdown_1);
            reaction_1(answer_2, Dropdown_2);
            reaction_1(answer_3, Dropdown_3);
            reaction_1(answer_4, Dropdown_4);
            reaction_1(answer_5, Dropdown_5);

            audio.PlayAnswerRight();

            controller.SuccessfulMinigame();
        } else
        {
            audio.PlayAnswerWrong();

            output.text = "Leider falsch. Versuch es noch einmal!";
        }


        //after 3 tries, dropdown shows if right or wrong
        tries = tries + 1;

        if (tries >= 3)
        {
            reaction_1(answer_1, Dropdown_1);
            reaction_1(answer_2, Dropdown_2);
            reaction_1(answer_3, Dropdown_3);
            reaction_1(answer_4, Dropdown_4);
            reaction_1(answer_5, Dropdown_5);
        }

    }



    // color dropdown
    public void reaction_1(answer answ, TMP_Dropdown dropdownColor)            
    {

        // Dropbox shows color for right or wrong answer
        ColorBlock rc = dropdownColor.colors;
        rc.normalColor = redColor;
        rc.selectedColor = redColor;

        ColorBlock gc = dropdownColor.colors;
        gc.normalColor = greenColor;
        gc.selectedColor = greenColor;


        //wrong answers
        if (answ == answer.wrong)
        {
            dropdownColor.colors = rc;
        }

        //rigth answer
        if (answ == answer.rigth)
        {
            dropdownColor.colors = gc;
        }

    }

}
