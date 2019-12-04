using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SentenceMaker : MonoBehaviour
{
    public TextMeshProUGUI output;
    public GameObject colorImg;
    public GameObject nounImg;
    public List<Sprite> nounSprites = new List<Sprite>();

    private Color _color;

    public void AddWord(string word)
    {
        output.text += word + " ";
        GameObject.Find(word).transform.parent.gameObject.SetActive(false);

        switch (word)
        {
            case "The Red":
                Debug.Log("clicked");
                _color = new Color(1.0f, 0.25f, 0.25f);
                colorImg.GetComponent<Image>().color = _color;
                colorImg.SetActive(true);
                break;

            case "The Green":
                Debug.Log("clicked");
                _color = new Color(0.25f, 1.0f, 0.25f);
                colorImg.GetComponent<Image>().color = _color;
                colorImg.SetActive(true);
                break;

            case "The Blue":
                Debug.Log("clicked");
                _color = new Color(.25f, 0.25f, 1.0f);
                colorImg.GetComponent<Image>().color = _color;
                colorImg.SetActive(true);
                break;

            case "The Yellow":
                Debug.Log("clicked");
                _color = new Color(1.0f, 1.0f, 0.25f);
                colorImg.GetComponent<Image>().color = _color;
                colorImg.SetActive(true);
                break;

            case "The Pink":
                Debug.Log("clicked");
                _color = new Color(1.0f, 0.25f, 1.0f);
                colorImg.GetComponent<Image>().color = _color;
                colorImg.SetActive(true);
                break;

            default:
                colorImg.GetComponent<Image>().color = Color.white;
                break;
        }
    }

    public void EnableNoun(int id)
    {
        colorImg.SetActive(false);
        nounImg.SetActive(true);
        nounImg.GetComponent<Image>().sprite = nounSprites[id];
        nounImg.GetComponent<Image>().color = _color;
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
