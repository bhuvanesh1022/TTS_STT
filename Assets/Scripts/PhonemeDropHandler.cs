using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PhonemeDropHandler : MonoBehaviour, IDropHandler
{

    public Transform phonemePanel;
    public SpeechManager speech;
    public Image smiley;
    public TextMeshProUGUI correctWord;
    public Sprite[] actualWord;
    public Sprite[] nonsenseWord;
    public SpeechManager manager;
    public GameObject DiyaPanel;
    public TextMeshProUGUI realWord;

    public bool wordDetected;

    string word2Check;

    public GameObject phoneme
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform rect = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
        {
            if (!phoneme)
            {
                ItemDragHandler.itemBeingDragged.SetParent(transform);
                manager.noOfSyllabes++;
            }
            else
            {
                Transform phonic = phoneme.transform;
                phonic.SetParent(phonic.GetComponent<ItemDragHandler>().startParent);
                phonic.localPosition = phonic.GetComponent<ItemDragHandler>().startPosition;
                ItemDragHandler.itemBeingDragged.SetParent(transform);
            }

            StartCoroutine(PlayPhoneme());
        }
    }

    IEnumerator PlayPhoneme()
    {
        string word = null;
        List<string> laugh = new List<string>() { "Ha! Ha!", "He! He!" };

        for (int i = 0; i < phonemePanel.childCount; i++)
        {
            if (phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>())
            {
                word += phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>().phoneme;

                if (manager.noOfSyllabes < 3)
                {
                    speech.Speak(phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>().audioClip);
                    yield return new WaitForSeconds(phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>().audioClip.length / 1.5f);
                    Debug.Log(word);
                }
                else 
                {
                    word2Check = word;

                    switch (word2Check)
                    {
                        case "bat":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            //smiley.sprite = actualWord[Random.Range(0, 2)];
                            //correctWord.text = word;
                            //smiley.enabled = true;
                            //correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[0]);
                            yield return new WaitForSeconds(3f);
                            //smiley.enabled = false;
                            //correctWord.transform.parent.gameObject.SetActive(false);
                            DiyaPanel.SetActive(false);
                            break;

                        case "not":
                            //speech.Speak(speech.correctAudio[1]);
                            //smiley.sprite = actualWord[Random.Range(0, 2)];
                            //correctWord.text = word;
                            //smiley.enabled = true;
                            //correctWord.transform.parent.gameObject.SetActive(true);
                            //yield return new WaitForSeconds(2f);
                            //smiley.enabled = false;
                            //correctWord.transform.parent.gameObject.SetActive(false);
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[1]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "bag":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[2]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "this":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[3]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "that":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[4]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "sit":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[5]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "sat":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[6]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "fin":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[7]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "fit":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[8]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "fig":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[9]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "bet":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[10]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "get":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[11]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "set":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[12]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "net":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[13]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "can":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[14]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "bin":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[15]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "cat":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[16]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "oat":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[17]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "got":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[18]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "beg":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[19]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "gif":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[20]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "big":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[22]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "fat":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[23]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "bit":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[24]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "son":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[25]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "toe":
                            realWord.text = word2Check;
                            DiyaPanel.SetActive(true);
                            yield return new WaitForSeconds(3f);
                            speech.Speak(speech.correctAudio[26]);
                            yield return new WaitForSeconds(3f);
                            DiyaPanel.SetActive(false);
                            break;

                        case "phat":
                            speech.Speak(speech.wrongAudio[0]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;


                        case "pheth":
                            speech.Speak(speech.wrongAudio[1]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "tths":
                            speech.Speak(speech.wrongAudio[2]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "phths":
                            speech.Speak(speech.wrongAudio[3]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "coth":
                            speech.Speak(speech.wrongAudio[4]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "phct":
                            speech.Speak(speech.wrongAudio[5]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "gbch":
                            speech.Speak(speech.wrongAudio[6]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "tphth":
                            speech.Speak(speech.wrongAudio[7]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "thpht":
                            speech.Speak(speech.wrongAudio[8]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "ebg":
                            speech.Speak(speech.wrongAudio[9]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "faph":
                            speech.Speak(speech.wrongAudio[10]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "phaf":
                            speech.Speak(speech.wrongAudio[11]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "cphth":
                            speech.Speak(speech.wrongAudio[12]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "theb":
                            speech.Speak(speech.wrongAudio[13]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "cng":
                            speech.Speak(speech.wrongAudio[14]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "tgph":
                            speech.Speak(speech.wrongAudio[15]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0, 2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        case "biph":
                            speech.Speak(speech.wrongAudio[16]);
                            smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                            smiley.enabled = true;
                            correctWord.text = laugh[Random.Range(0,2)];
                            correctWord.transform.parent.gameObject.SetActive(true);
                            yield return new WaitForSeconds(2f);
                            smiley.enabled = false;
                            correctWord.transform.parent.gameObject.SetActive(false);
                            break;

                        default:

                            if (i == 2)
                            {
                                for (int j = 0; j < phonemePanel.childCount; j++)
                                {
                                    Debug.Log("noRealWord...");
                                    speech.Speak(phonemePanel.GetChild(j).GetComponentInChildren<PhoneticManager>().audioClip);
                                    // To Proceduraly generate Reading
                                    yield return new WaitForSeconds(phonemePanel.GetChild(j).GetComponentInChildren<PhoneticManager>().audioClip.length / 1.5f);
                                }
                            }
                        break;
                    }
                }
            }
        }
    }
}
