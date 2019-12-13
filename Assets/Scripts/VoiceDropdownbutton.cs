﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoiceDropdownbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public string value;
    public int nounid;
    public bool isvoice;
    public int verbid;
   
    void Start()
    {
        if (this.gameObject.tag == "Verb")
        {
            type = 2;
         
        }
        else if (this.gameObject.tag == "Noun")
        {
            type = 1;

        }
        else if (this.gameObject.tag == "Adjective")
        {
            type = 0;
           
        }
        value = this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
    void Voicetext()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }

        if (SentenceMaker.sentenceMaker.voicetext.text == "")
            return;
        if (SentenceMaker.sentenceMaker.voicetext.text == value)
        {

            SentenceMaker.sentenceMaker.isvoicematched = true;

        }

        if (SentenceMaker.sentenceMaker.isvoicematched)

        {
            isvoice = true;
            if (this.gameObject.tag == "Verb")
            {
                type = 2;
                if (SentenceMaker.sentenceMaker.voicetext.text == value)
                {
                    Debug.Log("Text");
                    SentenceMaker.sentenceMaker.newoutputobject[2].GetComponentInChildren<Text>().text = value;
                    SentenceMaker.sentenceMaker.newoutputobject[2].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                }
                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[type].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
                /* SentenceMaker.sentenceMaker.isobject.SetActive(true);
                 SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[SentenceMaker.sentenceMaker.whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;*/

            }
            else if (this.gameObject.tag == "Adjective")
            {
                type = 0;
                // SentenceMaker.sentenceMaker.theobject.SetActive(true);
                if (SentenceMaker.sentenceMaker.voicetext.text == value)
                {
                    Debug.Log("Text");
                    SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                    SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                }
                switch (SentenceMaker.sentenceMaker.voicetext.text)
                {
                    case "BLUE":
                        Debug.Log("clicked");
                        SentenceMaker.sentenceMaker._color = new Color(0, 255f, 255f);
                        SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                        if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                        {
                            SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                            SentenceMaker.sentenceMaker.nounImg.SetActive(false);
                        }
                        SentenceMaker.sentenceMaker.colorImg.SetActive(true);

                        break;

                    case "GREEN":
                        Debug.Log("clicked");
                        SentenceMaker.sentenceMaker._color = new Color(0f, 255f, 0f);
                        SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                        if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                        {
                            SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                            SentenceMaker.sentenceMaker.nounImg.SetActive(false);
                        }
                        SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                        break;

                    case "YELLOW":
                        Debug.Log("clicked");
                        SentenceMaker.sentenceMaker._color = new Color(255f, 215f, 0f);
                        SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                        if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                        {
                            SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                            SentenceMaker.sentenceMaker.nounImg.SetActive(false);
                        }
                        SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                        break;

                    case "ORANGE":
                        Debug.Log("clicked");
                        SentenceMaker.sentenceMaker._color = new Color(258f, 141f, 0f);
                        SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                        if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                        {
                            SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                            SentenceMaker.sentenceMaker.nounImg.SetActive(false);
                        }
                        SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                        break;

                    case "PINK":
                        Debug.Log("clicked");
                        SentenceMaker.sentenceMaker._color = new Color(255f, 0f, 143f);
                        SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                        if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                        {
                            SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                            SentenceMaker.sentenceMaker.nounImg.SetActive(false);
                        }
                        SentenceMaker.sentenceMaker.colorImg.SetActive(true);
                        break;

                    default:

                        break;
                }
            }
            else if (this.gameObject.tag == "Noun")
            {
                type = 1;
                if (SentenceMaker.sentenceMaker.voicetext.text == value)
                {
                    Debug.Log("Text");
                    SentenceMaker.sentenceMaker.newoutputobject[1].GetComponentInChildren<Text>().text =value;
                    SentenceMaker.sentenceMaker.newoutputobject[1].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                }
                if (SentenceMaker.sentenceMaker.colorImg.activeInHierarchy)
                {
                    SentenceMaker.sentenceMaker.colorImg.SetActive(false);
                    SentenceMaker.sentenceMaker.nounImg.SetActive(true);
                }
                SentenceMaker.sentenceMaker.nounImg.SetActive(true);
                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[nounid].transform.GetChild(SentenceMaker.sentenceMaker.whicverb).GetComponent<SpriteRenderer>().sprite;
                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker.colorImg.GetComponent<Image>().color;

            }
       
            SentenceMaker.sentenceMaker.voicetext.text = "";
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }


    }
   

    // Update is called once per frame
    void Update()
    {
        
            Voicetext();
          
    }
}