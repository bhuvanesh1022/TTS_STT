using System.Collections;
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

        for (int i = 0; i < phonemePanel.childCount; i++)
        {
            if (phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>())
            {
                word += phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>().phoneme;
                Debug.Log(word);

                switch (word)
                {
                    case "bat":
                        speech.Speak(speech.correctAudio[0]);
                        smiley.sprite = actualWord[Random.Range(0, 1)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "not":
                        speech.Speak(speech.correctAudio[1]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "bag":
                        speech.Speak(speech.correctAudio[2]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "this":
                        speech.Speak(speech.correctAudio[3]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "that":
                        speech.Speak(speech.correctAudio[4]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "sit":
                        speech.Speak(speech.correctAudio[5]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "sat":
                        speech.Speak(speech.correctAudio[6]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "fin":
                        speech.Speak(speech.correctAudio[7]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "fit":
                        speech.Speak(speech.correctAudio[8]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "fig":
                        speech.Speak(speech.correctAudio[9]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "bet":
                        speech.Speak(speech.correctAudio[10]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "get":
                        speech.Speak(speech.correctAudio[11]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "set":
                        speech.Speak(speech.correctAudio[12]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "net":
                        speech.Speak(speech.correctAudio[13]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "can":
                        speech.Speak(speech.correctAudio[14]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "bin":
                        speech.Speak(speech.correctAudio[15]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "cat":
                        speech.Speak(speech.correctAudio[16]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "oat":
                        speech.Speak(speech.correctAudio[17]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "got":
                        speech.Speak(speech.correctAudio[18]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "beg":
                        speech.Speak(speech.correctAudio[19]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "gif":
                        speech.Speak(speech.correctAudio[20]);
                        smiley.sprite = actualWord[Random.Range(0, 2)];
                        correctWord.text = word;
                        smiley.enabled = true;
                        correctWord.transform.parent.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        correctWord.transform.parent.gameObject.SetActive(false);
                        break;

                    case "phat":
                        speech.Speak(speech.wrongAudio[0]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;


                    case "pheth":
                        speech.Speak(speech.wrongAudio[1]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "tths":
                        speech.Speak(speech.wrongAudio[2]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "phths":
                        speech.Speak(speech.wrongAudio[3]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "coth":
                        speech.Speak(speech.wrongAudio[4]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "phct":
                        speech.Speak(speech.wrongAudio[5]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "gbch":
                        speech.Speak(speech.wrongAudio[6]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "tphth":
                        speech.Speak(speech.wrongAudio[7]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "thpht":
                        speech.Speak(speech.wrongAudio[8]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "ebg":
                        speech.Speak(speech.wrongAudio[9]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "faph":
                        speech.Speak(speech.wrongAudio[10]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "phaf":
                        speech.Speak(speech.wrongAudio[11]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "cphth":
                        speech.Speak(speech.wrongAudio[12]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "theb":
                        speech.Speak(speech.wrongAudio[13]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "cng":
                        speech.Speak(speech.correctAudio[14]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "tgph":
                        speech.Speak(speech.correctAudio[15]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    case "biph":
                        speech.Speak(speech.correctAudio[16]);
                        smiley.sprite = nonsenseWord[Random.Range(0, 2)];
                        smiley.enabled = true;
                        yield return new WaitForSeconds(2f);
                        smiley.enabled = false;
                        break;

                    default:
                        speech.Speak(phoneme.GetComponentInChildren<PhoneticManager>().audioClip);

                        /*
                         * To Proceduraly generate Reading
                        yield return new WaitForSeconds(phonemePanel.GetChild(i).GetComponentInChildren<PhoneticManager>().audioClip.length / 1.5f);
                        *
                        */                       
                        break;
                }
            }
        }
    }
}
