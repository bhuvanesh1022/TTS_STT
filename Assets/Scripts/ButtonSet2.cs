﻿using System.Collections;
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



    public void EnableNoun(int verbid)
    {


        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
        SentenceMaker.sentenceMaker. whichanimal = verbid;
        SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[SentenceMaker.sentenceMaker.whichanimal].transform.GetChild(SentenceMaker.sentenceMaker.whicverb).GetComponent<SpriteRenderer>().sprite;
      //  SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color;
    }
    public void Enableverb(int verbid)
    {
      //  SentenceMaker.sentenceMaker.whichanimal = verbid;
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
        SentenceMaker.sentenceMaker.whicverb = verbid;
        if (SentenceMaker.sentenceMaker.colorImg.activeInHierarchy)
        {
            SentenceMaker.sentenceMaker. colorImg.SetActive(false);
            SentenceMaker.sentenceMaker. nounImg.SetActive(true);
        }
        SentenceMaker.sentenceMaker. nounImg.SetActive(true);
        SentenceMaker.sentenceMaker. nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker. verbsprite[SentenceMaker.sentenceMaker.whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
    }

}
