using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SentenceMaker : MonoBehaviour
{
    public static SentenceMaker sentenceMaker;
    public TextMeshProUGUI output;
    public GameObject colorImg;
    public GameObject nounImg;
    public List<Sprite> nounSprites = new List<Sprite>();
    public List<GameObject> verbsprite = new List<GameObject>();
    public List<GameObject> outputobject = new List<GameObject>();
    public List<GameObject> typeparent = new List<GameObject>();
    public List<GameObject> newoutputobject = new List<GameObject>();
    public Text voicetext;
   
    private Color _color;
    public GameObject refbuttonobjectparent;
    public GameObject refbutton;
    public bool isclicked;
    public GameObject g;
    public string words;
    public bool isvoicematched;
    public GameObject theobject;
    public GameObject isobject;
    public int whicverb;
    public int whichanimal;
    public List<Transform> outpurposition = new List<Transform>();
    public void AddWord(string word)
    {
        string detectedWord = word.Trim();

        words = detectedWord;
       
        switch (detectedWord)
        {
            case "Blue":
                Debug.Log("clicked");
                _color = new Color(0, 255f, 255f);
                colorImg.GetComponent<Image>().color = _color;
                if (nounImg.activeInHierarchy)
                {
                    colorImg.SetActive(true);
                    nounImg.SetActive(false);
                }
                colorImg.SetActive(true);
                break;

            case "Green":
                Debug.Log("clicked");
                _color = new Color(0f, 255f,0f);
                colorImg.GetComponent<Image>().color = _color;
                if (nounImg.activeInHierarchy)
                {
                    colorImg.SetActive(true);
                    nounImg.SetActive(false);
                }
                colorImg.SetActive(true);
                break;

            case "Yellow":
                Debug.Log("clicked");
                _color = new Color(255f, 215f, 0f);
                colorImg.GetComponent<Image>().color = _color;
                if (nounImg.activeInHierarchy)
                {
                    colorImg.SetActive(true);
                    nounImg.SetActive(false);
                }
                colorImg.SetActive(true);
                break;

            case "Orange":
                Debug.Log("clicked");
                _color = new Color(258f, 141f, 0f);
                colorImg.GetComponent<Image>().color = _color;
                if (nounImg.activeInHierarchy)
                {
                    colorImg.SetActive(true);
                    nounImg.SetActive(false);
                }
                colorImg.SetActive(true);
                break;

            case "Pink":
                Debug.Log("clicked");
                _color = new Color(255f, 0f, 143f);
                colorImg.GetComponent<Image>().color = _color;
                if (nounImg.activeInHierarchy)
                {
                    colorImg.SetActive(true);
                    nounImg.SetActive(false);
                }
                colorImg.SetActive(true);
                break;

                default:
                colorImg.GetComponent<Image>().color = Color.white;
                break;
        }
        GameObject.Find(detectedWord).transform.parent.gameObject.SetActive(false);
    }

    public void EnableNoun(int id)
    {
        if (colorImg.activeInHierarchy)
        {
            colorImg.SetActive(false);
            nounImg.SetActive(true);
        }
        whichanimal = id;
        nounImg.SetActive(true);
        nounImg.GetComponent<Image>().sprite = nounSprites[id];
        nounImg.GetComponent<Image>().color = _color;
    }
    public void EnableVerb(int verbid)
    {
        if (colorImg.activeInHierarchy)
        {
            colorImg.SetActive(false);
            nounImg.SetActive(true);
        }
        nounImg.SetActive(true);
        nounImg.GetComponent<Image>().sprite = verbsprite[whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
        whicverb = verbid;
    }
    private void Update()
    {
        NewObjectAdd();
       
    }
   

    public  void NewObjectAdd()
    {
        if (outputobject.Count<=0 )
            return;
        if (isclicked||isvoicematched)
        {
           


                    refbutton.GetComponentInChildren<Text>().text = outputobject[outputobject.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text;
                    refbutton.GetComponentInChildren<Text>().color = outputobject[outputobject.Count - 1].GetComponent<Image>().color;
                  
                    refbutton.GetComponent<Image>().sprite = outputobject[outputobject.Count-1].GetComponent<Image>().sprite;
                    refbutton.GetComponent<Wordclick>().type = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().type;
            refbutton.GetComponent<Wordclick>().caninstantiate = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().caninstantiate;
            refbutton.GetComponent<Button>().onClick.AddListener(delegate { AddWord(refbutton.gameObject.name); });
            if (!refbutton.GetComponent<OutputButton>())
            {
                refbutton.AddComponent<OutputButton>();
            }
            
            refbutton.GetComponent<Wordclick>().enabled = false;
               //     refbutton.GetComponent<Wordclick>().isinstantiated = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().isinstantiated;
                    refbutton.name = outputobject[outputobject.Count - 1].name;
            if (outputobject.Count > 3)
                return;
         
                g = Instantiate(refbutton, outpurposition[outputobject.Count - 1].position,Quaternion.identity,refbuttonobjectparent.transform.parent);
                newoutputobject.Add(g);
            
                 

            isvoicematched = false;
       
          isclicked = false;
          
        }
      
        
    }
   
 
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
