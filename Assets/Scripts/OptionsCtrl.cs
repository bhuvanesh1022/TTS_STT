using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCtrl : MonoBehaviour
{
    public bool isSelected;
    public List<OptionsCtrl> options = new List<OptionsCtrl>();

    public void SelectedPhoneme()
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].isSelected = false;
            options[i].GetComponent<Image>().color = Color.white;
        }

        isSelected = true;
        GetComponent<Image>().color = Color.green;
    }
}
