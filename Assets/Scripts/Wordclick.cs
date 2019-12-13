using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wordclick : MonoBehaviour
{
    public int type;
   // public bool isinstantiated;
    public bool caninstantiate;
  
    public int nounid;
    public int verbid;
    private void Start()
    {
       
        this.gameObject.GetComponent<Button>().onClick.AddListener(AddClicked);

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
    }


    void AddClicked()
    {
      
       
        if (!caninstantiate)
        {
            if (SentenceMaker.sentenceMaker == null)
            {
                SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
            }
            SentenceMaker.sentenceMaker.isclicked = true;
            //  isinstantiated = true;
            caninstantiate = true;
           
            SentenceMaker.sentenceMaker.outputobject.Add(this.gameObject);
            if (this.gameObject.tag == "Verb")
            {
                type = 2;
                SentenceMaker.sentenceMaker.isobject.SetActive(true);
            }
            else if (this.gameObject.tag == "Noun")
            {
                type = 1;
             
            }
            else if (this.gameObject.tag == "Adjective")
            {
                type = 0;
                SentenceMaker.sentenceMaker.theobject.SetActive(true);
            }
        }
    }

    public void Changinginplay()
    {
        for (int i = 0; i < SentenceMaker.sentenceMaker.newoutputobject.Count; i++)
        {
            if (SentenceMaker.sentenceMaker.outputobject[i].GetComponent<Wordclick>().type==type)
            {
               
               
                SentenceMaker.sentenceMaker.newoutputobject[i].gameObject.GetComponentInChildren<Text>().text = this.gameObject.name;
                SentenceMaker.sentenceMaker.newoutputobject[i].gameObject.GetComponentInChildren<Text>().text = SentenceMaker.sentenceMaker.newoutputobject[i].gameObject.GetComponentInChildren<Text>().text.ToUpper();
                SentenceMaker.sentenceMaker.newoutputobject[i].gameObject.GetComponentInChildren<Text>().color = this.gameObject.GetComponent<Image>().color;

            }

        }
       
    }
   
    private void Update()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
      
        if (SentenceMaker.sentenceMaker.outputobject!=null)
        {
         
            this.gameObject.GetComponent<Button>().onClick.AddListener(Changinginplay);
        }
    }

    void Dropdown()
    {
        if (SentenceMaker.sentenceMaker == null)
        {
            SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
        }
        foreach (GameObject g in SentenceMaker.sentenceMaker.newoutputobject)
        {
           if( g.GetComponent<Wordclick>().type==type)
            {
                g.GetComponentInChildren<Text>().text = this.gameObject.GetComponentInChildren<Text>().text;
                g.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
                g.GetComponent<Wordclick>().type = type;
            }
        }
    }
}
