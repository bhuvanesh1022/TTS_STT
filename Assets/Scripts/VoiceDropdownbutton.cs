using System.Collections;
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
        if (SentenceMaker.sentenceMaker.alternativenames.Contains(this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text))
        {
            SentenceMaker.sentenceMaker.index = SentenceMaker.sentenceMaker.alternativenames.FindIndex(x => x == this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
            SentenceMaker.sentenceMaker.voicetext.text = SentenceMaker.sentenceMaker.alternativenames[SentenceMaker.sentenceMaker.index];
        }
        if (!SentenceMaker.sentenceMaker.isinstantiated && SentenceMaker.sentenceMaker.wordrecorded != "" && SentenceMaker.sentenceMaker.wordrecorded != "WORDS NOT DETECTED.")
        {
            SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[0];
            SentenceMaker.sentenceMaker.speechbubble.SetActive(true);
            SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "I'm sorry, I didn't really understand that." + "\n Try again?.";

        }
        if (SentenceMaker.sentenceMaker.voicetext.text == value)
        {

            SentenceMaker.sentenceMaker.isvoicematched = true;
        
            Debug.Log("word");
            SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[0];
            SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Awesome. Did you know you can CHANGE any of your choices by TAPPING on them? Go ahead, try it.";

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
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color; ;
                    SentenceMaker.sentenceMaker.whicverb = verbid;
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[SentenceMaker.sentenceMaker.whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
                }
                   
                  

                }
                else if (this.gameObject.tag == "Adjective")
                {
                    type = 0;
                // SentenceMaker.sentenceMaker.theobject.SetActive(true);
                if (SentenceMaker.sentenceMaker.voicetext.text == value)
                {
                    Debug.Log("Text");


                    switch (SentenceMaker.sentenceMaker.voicetext.text)
                    {
                        case "BLUE":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(0, 255f, 255f);

                            if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                            {

                                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                            }


                            break;

                        case "GREEN":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(0f, 255f, 0f);

                            if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                            {

                                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                            }

                            break;

                        case "YELLOW":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(255f, 215f, 0f);

                            if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                            {

                                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                            }

                            break;

                        case "ORANGE":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(258f, 141f, 0f);

                            if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                            {

                                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                            }

                            break;

                        case "PINK":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(255f, 0f, 143f);

                            if (SentenceMaker.sentenceMaker.nounImg.activeInHierarchy)
                            {

                                SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().text = value;
                                SentenceMaker.sentenceMaker.newoutputobject[0].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                            }

                            break;

                        default:

                            break;
                    }
                }
                }
                else if (this.gameObject.tag == "Noun")
                {
                    type = 1;
                    if (SentenceMaker.sentenceMaker.voicetext.text == value)
                    {
                        Debug.Log("Text");
                        SentenceMaker.sentenceMaker.newoutputobject[1].GetComponentInChildren<Text>().text = value;
                        SentenceMaker.sentenceMaker.newoutputobject[1].GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[nounid].transform.GetChild(SentenceMaker.sentenceMaker.whicverb).GetComponent<SpriteRenderer>().sprite;
                    SentenceMaker.sentenceMaker.whichanimal = nounid;
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = SentenceMaker.sentenceMaker._color; ;
                }
                   
                    
                   

                }

            SentenceMaker.sentenceMaker.isvoicematched = false;
            SentenceMaker.sentenceMaker.voicetext.text = "";
            this.gameObject.transform.parent.gameObject.SetActive(false);

            
        }

    }
   

    // Update is called once per frame
    void Update()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }

        Voicetext();
        if (!this.gameObject.activeInHierarchy)
            return;
      //  StartCoroutine("Notrecogonizedword");


    }
    IEnumerator Notrecogonizedword()

    {
        if (SentenceMaker.sentenceMaker.voicetext.text != "")
        {
            SentenceMaker.sentenceMaker.voicetext.text = SentenceMaker.sentenceMaker.voicetext.text.ToUpper();
            if (SentenceMaker.sentenceMaker.voicetext.text !=value)
            {
                SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(true);
                if (SentenceMaker.sentenceMaker.voicetext.text == "WORDS NOT DETECTED." && SentenceMaker.sentenceMaker.iswordrecogonized)
                {
                    SentenceMaker.sentenceMaker.wordsnotdetected.text = " WORDS NOT DETECTED";
                    SentenceMaker.sentenceMaker.iswordrecogonized = false;
                }
                else if (SentenceMaker.sentenceMaker.voicetext.text == value)
                {
                    Debug.Log(value);
                   // SentenceMaker.sentenceMaker.wordsnotdetected.text = "I Couldn't Understand You" + "\n I Detected the Word" + " " + SentenceMaker.sentenceMaker.voicetext.text + "\n Please try again with the word in the list" + "\n Can you read the word you want";
                    SentenceMaker.sentenceMaker.iswordrecogonized = false;
                }
                    yield return new WaitForSeconds(2f);
                SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(false);
                SentenceMaker.sentenceMaker.voicetext.text = "";
                SentenceMaker.sentenceMaker.wordsnotdetected.text = "";

            }else
            {
                SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(false);
               

            }
        }

    }
}
