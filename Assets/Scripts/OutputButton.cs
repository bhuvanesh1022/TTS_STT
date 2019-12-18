using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutputButton : MonoBehaviour
{
    public int wordtype;
   
    private void Update()
    {
        if (this.gameObject.tag == "Verb")
        {
            wordtype = 2;

        }
        else if (this.gameObject.tag == "Noun")
        {
            wordtype = 1;

        }
        else if (this.gameObject.tag == "Adjective")
        {
            wordtype = 0;

        }

        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Dropdownfn(this.gameObject.GetComponent<Wordclick>().type); });
        }
      Samewords();
    }
    // Start is called before the first frame update
    public void Dropdownfn(int type)
    {
        if (SentenceMaker.sentenceMaker.newoutputobject.Count >= 3)
        {

            SentenceMaker.sentenceMaker.isdropdownopen = true;

              type = this.gameObject.GetComponent<Wordclick>().type; 
            wordtype = type;
            switch (type)
            {  
                case 0:
                    SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Go on - READ the word you want to choose";
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(true);
                   
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(false);
                    break;
                case 1:
                    SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Go on - READ the word you want to choose";
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(true);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(false);
                    break;
                case 2:
                    SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Go on - READ the word you want to choose";
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(true);
                    break;


            }
        }
    }

    public void Samewords()
    {
        if (SentenceMaker.sentenceMaker.newoutputobject.Count >= 3 && !SentenceMaker.sentenceMaker.isdropdownopen)
        {
            SentenceMaker.sentenceMaker.speechbubble.SetActive(true);
            SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = "Awesome. Did you know you can CHANGE any of your choices by TAPPING on them? Go ahead, try it.";
        /*    int w = this.gameObject.GetComponent<Wordclick>().type;
         
            switch (w)
            {
                case 0:
                  
                  if(SentenceMaker.sentenceMaker.typeparent[0].transform.GetChild(GetComponent<ButtonSet2>().whichplace).GetComponentInChildren<TextMeshProUGUI>().text != SentenceMaker.sentenceMaker.voicetext.text)
                    {

                        SentenceMaker.sentenceMaker.iswordrecogonized = false;
                    }
                   
                    break;
                case 1:

                    if (SentenceMaker.sentenceMaker.typeparent[1].transform.GetChild(GetComponent<ButtonSet2>().whichplace).GetComponentInChildren<TextMeshProUGUI>().text != SentenceMaker.sentenceMaker.voicetext.text)
                    {

                        SentenceMaker.sentenceMaker.iswordrecogonized = false;
                    }


                    break;
                case 2:

                    if (SentenceMaker.sentenceMaker.typeparent[2].transform.GetChild(GetComponent<ButtonSet2>().whichplace).GetComponentInChildren<TextMeshProUGUI>().text != SentenceMaker.sentenceMaker.voicetext.text)
                    {

                        SentenceMaker.sentenceMaker.iswordrecogonized = false;
                    }

                    break;


            }*/
        }



    }
}
