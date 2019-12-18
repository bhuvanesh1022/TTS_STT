using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoiceFirstbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public string value;
    public int nounid;
    public int verbid;
   public int index;
    private Rigidbody rb;
void Start()
    {
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
       if(!SentenceMaker.sentenceMaker.isinstantiated&&SentenceMaker.sentenceMaker.wordrecorded!=""&& SentenceMaker.sentenceMaker.wordrecorded!= "WORDS NOT DETECTED." &&SentenceMaker.sentenceMaker.newoutputobject.Count<3)
        {
            SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[0];
            SentenceMaker.sentenceMaker.speechbubble.SetActive(true);
            SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "I'm sorry, I didn't really understand that." + "\n Try again?.";
             SentenceMaker.sentenceMaker.isstartrecord = true;
        }
        if (SentenceMaker.sentenceMaker.voicetext.text == value )
        {

            SentenceMaker.sentenceMaker.isvoicematched = true;
           
             Debug.Log("word");
           
              SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[0];
            SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Great Now READ the next word you want.";
            
            SentenceMaker.sentenceMaker.startseconds = 2f;
            SentenceMaker.sentenceMaker.speechbubble.SetActive(true);
        }
       if(SentenceMaker.sentenceMaker.isvoicematched && SentenceMaker.sentenceMaker.newoutputobject.Count==2)
        {
            SentenceMaker.sentenceMaker.isstartrecord = false;

        }



        if (SentenceMaker.sentenceMaker.newoutputobject.Count <= 3)
        {
            if (SentenceMaker.sentenceMaker.isvoicematched)
            {
                if (this.gameObject.tag == "Verb")
                {
                    SentenceMaker.sentenceMaker.whichpos = 2;
                       type = 2;
                    SentenceMaker.sentenceMaker.isobject.SetActive(true);
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.verbsprite[SentenceMaker.sentenceMaker.whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
                    SentenceMaker.sentenceMaker.whicverb = verbid;
                    SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                }
                else if (this.gameObject.tag == "Adjective")
                {
                    type = 0;
                    SentenceMaker.sentenceMaker.whichpos = 0;
                    SentenceMaker.sentenceMaker.theobject.SetActive(true);
                  
                   
                    switch (SentenceMaker.sentenceMaker.voicetext.text)
                    {
                        case "BLUE":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(0, 255f, 255f);
                            SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(0, 255f, 255f);
                           
                            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                           
                            break;

                        case "GREEN":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(0f, 255f, 0f);
                            SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(0f, 255f, 0f);
                           
                            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                         
                            break;

                        case "YELLOW":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(255f, 215f, 0f);
                            SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(255f, 215f, 0f);
                           
                            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                           
                            break;

                        case "ORANGE":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(255f, 125f, 0f);
                            SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(255f, 125f, 0f);
                         
                            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                           
                            break;

                        case "PINK":
                            Debug.Log("clicked");
                            SentenceMaker.sentenceMaker._color = new Color(255f, 0f, 143f);
                            SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(255f, 0f, 143f);
                           
                            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                           
                            break;

                        default:

                            break;
                    }

                }
                else if (this.gameObject.tag == "Noun")
                {
                    type = 1;
                    SentenceMaker.sentenceMaker.whichpos = 1;
                    if (SentenceMaker.sentenceMaker.colorImg.activeInHierarchy)
                    {
                        SentenceMaker.sentenceMaker.colorImg.SetActive(false);
                        SentenceMaker.sentenceMaker.nounImg.SetActive(true);
                    }
                    SentenceMaker.sentenceMaker.nounImg.SetActive(true);
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.nounSprites[nounid];
                    SentenceMaker.sentenceMaker.nounImg.GetComponent<Image>().color = new Color(255,255,255);
                    SentenceMaker.sentenceMaker.whichanimal = nounid;
                    SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
                }
               // SentenceMaker.sentenceMaker.isstartrecord = true;

                //  SentenceMaker.sentenceMaker.isvoicematched = false;
                SentenceMaker.sentenceMaker.voicetext.text = "";
                this.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
        StartCoroutine("Wait");
        if (SentenceMaker.sentenceMaker.newoutputobject.Count >= 3)
            return;
        Voicetext();
     /*   if (!this.gameObject.activeInHierarchy)
            return;
       Notrecogonizedword();*/
       


    }
   IEnumerator Wait()
    {
        if(SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(2f);
         //   SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(false);
        }
    }


    void Notrecogonizedword()

    {


       
      



            if (SentenceMaker.sentenceMaker.iswordrecogonized == false && SentenceMaker.sentenceMaker.voicetext.text!= "WORDS NOT DETECTED."&& SentenceMaker.sentenceMaker.voicetext.text!="")
            {
            
                SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(true);
                Debug.Log("NOT"); Debug.Log(SentenceMaker.sentenceMaker.voicetext.text);
                SentenceMaker.sentenceMaker.wordsnotdetected.text = "I Couldn't Understand You" + "\n I Detected the Word" + " " + SentenceMaker.sentenceMaker.voicetext.text + "\n Please try again with the word in the list" + "\n Can you read the word you want";
                
            }
            else if (SentenceMaker.sentenceMaker.voicetext.text == "WORDS NOT DETECTED." && SentenceMaker.sentenceMaker.iswordrecogonized == false)
            {
             
                SentenceMaker.sentenceMaker.wordsnotdetected.gameObject.SetActive(true);
                Debug.Log(SentenceMaker.sentenceMaker.voicetext.text);
                SentenceMaker.sentenceMaker.wordsnotdetected.text = " WORDS NOT DETECTED";
                SentenceMaker.sentenceMaker.voicetext.text = "";
            }

        
    }
        

    
}
