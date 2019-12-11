using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSet2 : MonoBehaviour
{
    public int whichplace;


    public void Imagedropdown()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
        //  SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.nounSprites[whichplace];
        SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = this.gameObject.GetComponent<Image>().color;

    }



    public void EnableNoun()
    {


        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }

        SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.nounSprites[whichplace];
      //  SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color;
    }

}
