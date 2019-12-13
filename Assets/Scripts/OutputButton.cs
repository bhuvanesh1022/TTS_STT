using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
    // Start is called before the first frame update
    public void Dropdownfn(int type)
    {
        if (SentenceMaker.sentenceMaker.newoutputobject.Count == 3)
        {

            type = this.gameObject.GetComponent<Wordclick>().type; 
            wordtype = type;
            switch (type)
            {
                case 0:
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(true);
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(false);
                    break;
                case 1:
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(true);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(false);
                    break;
                case 2:
                    SentenceMaker.sentenceMaker.typeparent[0].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[1].SetActive(false);
                    SentenceMaker.sentenceMaker.typeparent[2].SetActive(true);
                    break;


            }
        }
    }
}
