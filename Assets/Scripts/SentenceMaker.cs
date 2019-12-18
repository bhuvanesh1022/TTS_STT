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
    public List<Sprite> Diyasprite = new List<Sprite>();
    public GameObject diyaobj;
    public List<string> allnames = new List<string>();
    public Text voicetext;
    public Text wordsnotdetected;

    public Color _color;
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
    public string wordrecorded;
    public bool iswordrecogonized;
    public GameObject speechbubble;
    public List<string> alternativenames=new List<string>();
    public bool notanyofword;
    public int index;
    public bool isrecorded;
    public bool isrecording;
    public bool isdropdownopen;

    public bool isinstantiated;
    public bool isstartrecord;
    public float startseconds;
    public float maxseconds;
    public int whichpos;
    private void Start()
    {
        iswordrecogonized = true;
        diyaobj.GetComponent<Image>().sprite = Diyasprite[2];
        diyaobj.SetActive(true);
        speechbubble.SetActive(true);
        speechbubble.GetComponentInChildren<Text>().text = "Go on - READ the word you want to choose";
        isstartrecord = true;
    }


    public void AddWord(string word)
    {
        if (!isrecorded)
        {
            whichpos = 0;
            string detectedWord = word.Trim();

            words = detectedWord;

            switch (detectedWord)
            {
                case "Blue":
                    Debug.Log("clicked");
                    _color = new Color(0, 255f, 255f);
                   // colorImg.GetComponent<Image>().color = _color;
                    nounImg.GetComponent<Image>().color = _color;
                    break;

                case "Green":
                    Debug.Log("clicked");
                    _color = new Color(0f, 255f, 0f);
                  //  colorImg.GetComponent<Image>().color = _color;
                    nounImg.GetComponent<Image>().color = _color;
                  
                    break;

                case "Yellow":
                    Debug.Log("clicked");
                    _color = new Color(255f, 215f, 0f);
                   // colorImg.GetComponent<Image>().color = _color;
                    nounImg.GetComponent<Image>().color = _color;
                    break;

                case "Orange":
                    Debug.Log("clicked");
                    _color = new Color(258f, 141f, 0f);
                  //  colorImg.GetComponent<Image>().color = _color;
                    nounImg.GetComponent<Image>().color = _color;


                    break;

                case "Pink":
                    Debug.Log("clicked");
                    _color = new Color(255f, 0f, 143f);
                //    colorImg.GetComponent<Image>().color = _color;
                    nounImg.GetComponent<Image>().color = _color;
                    break;

                default:
                    colorImg.GetComponent<Image>().color = Color.white;
                    break;
            }
            GameObject.Find(detectedWord).transform.parent.gameObject.SetActive(false);
        }
    }


    public void EnableNoun(int id)
    {
        if (!isrecorded)
        {
            whichpos = 1;
            if (colorImg.activeInHierarchy)
            {
                colorImg.SetActive(false);
                nounImg.SetActive(true);
            }
            whichanimal = id;
            nounImg.SetActive(true);
            nounImg.GetComponent<Image>().sprite = nounSprites[id];
            nounImg.GetComponent<Image>().color = new Color(255,255,255);
        }
    }
    public void EnableVerb(int verbid)
    {
        if (!isrecorded)
        {
            whichpos = 2;
            if (colorImg.activeInHierarchy)
            {
                colorImg.SetActive(false);
                nounImg.SetActive(true);
            }
            nounImg.SetActive(true);
            nounImg.GetComponent<Image>().sprite = verbsprite[whichanimal].transform.GetChild(verbid).GetComponent<SpriteRenderer>().sprite;
            whicverb = verbid;
        }
    }
    private void Update()
    {
        wordrecorded = voicetext.text;
        NewObjectAdd();
      
        //   StartCoroutine("WaitSec");

        // whicverb = outputobject[3].GetComponent<OutputButton>().verbid;
    //    Samewords();
    }
   

    public  void NewObjectAdd()
    {
        if (outputobject.Count<=0 )
            return;
        if ((isclicked&&!isrecorded)||isvoicematched)
        {
          
            if (newoutputobject.Count >= 3)
                return;
            SentenceMaker.sentenceMaker.startseconds = 2f;
            Debug.Log("Issemtencemaking");
            refbutton.GetComponentInChildren<Text>().text = outputobject[outputobject.Count - 1].GetComponentInChildren<TextMeshProUGUI>().text;
                    refbutton.GetComponentInChildren<Text>().color = outputobject[outputobject.Count - 1].GetComponent<Image>().color;
                  
                    refbutton.GetComponent<Image>().sprite = outputobject[outputobject.Count-1].GetComponent<Image>().sprite;
                    refbutton.GetComponent<Wordclick>().type = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().type;

            refbutton.GetComponent<Wordclick>().caninstantiate = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().caninstantiate;
            refbutton.GetComponent<Button>().onClick.AddListener(delegate { AddWord(refbutton.gameObject.name); });
            Debug.Log("type");
            if (!refbutton.GetComponent<OutputButton>())
            {
                refbutton.AddComponent<OutputButton>();
            }
            Debug.Log("Issemtencemaking1");
            refbutton.GetComponent<Wordclick>().enabled = false;
               //     refbutton.GetComponent<Wordclick>().isinstantiated = outputobject[outputobject.Count - 1].GetComponent<Wordclick>().isinstantiated;
                    refbutton.name = outputobject[outputobject.Count - 1].name;
           
         
                g = Instantiate(refbutton, outpurposition[whichpos].position,Quaternion.identity,refbuttonobjectparent.transform.parent);
                newoutputobject.Add(g);
            isinstantiated = true;
                 

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
   
    public void Samewords()
    {


        if (voicetext.text == "")
            return;
       voicetext.text = voicetext.text.ToUpper();

        for (int i = 0; i < GameObject.FindGameObjectWithTag("Adjective").transform.childCount; i++)
        {


            if (GameObject.FindGameObjectWithTag("Adjective").transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text != voicetext.text)
            {
                Debug.Log(0);
                iswordrecogonized = false;

            }
        }
        for (int j = 0; j < GameObject.FindGameObjectWithTag("Noun").transform.childCount; j++)
        {
            if (GameObject.FindGameObjectWithTag("Noun").transform.GetChild(j).GetComponentInChildren<TextMeshProUGUI>().text != voicetext.text)
            {
                Debug.Log(1);
                iswordrecogonized = false;
            }

        }


        for (int k = 0; k < GameObject.FindGameObjectWithTag("Verb").transform.childCount; k++)
        {
            if (GameObject.FindGameObjectWithTag("Verb").transform.GetChild(k).GetComponentInChildren<TextMeshProUGUI>().text != voicetext.text)
            {
                Debug.Log(2);
                iswordrecogonized = false;
            }


        }

       

            }
        

    


    }
