﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples
{
    public class GCSR : MonoBehaviour
    {
        private GCSpeechRecognition _speechRecognition;

    
        public Button _startRecordButton;

        public Image _speechRecognitionState;

        public Text _resultText;

    
        public Dropdown _microphoneDevicesDropdown;

       
        public InputField _contextPhrasesInputField;
        public Image _voiceLevelImage;
        public bool Canrecord;
        public static GCSR gCSR;
      

       
        private void Start()
        {
            _speechRecognition = GCSpeechRecognition.Instance;
            _speechRecognition.RecognizeSuccessEvent += RecognizeSuccessEventHandler;
            _speechRecognition.RecognizeFailedEvent += RecognizeFailedEventHandler;
            //_speechRecognition.LongRunningRecognizeSuccessEvent += LongRunningRecognizeSuccessEventHandler;
            //_speechRecognition.LongRunningRecognizeFailedEvent += LongRunningRecognizeFailedEventHandler;
            _speechRecognition.GetOperationSuccessEvent += GetOperationSuccessEventHandler;
            _speechRecognition.GetOperationFailedEvent += GetOperationFailedEventHandler;
            _speechRecognition.ListOperationsSuccessEvent += ListOperationsSuccessEventHandler;
            _speechRecognition.ListOperationsFailedEvent += ListOperationsFailedEventHandler;

            _speechRecognition.FinishedRecordEvent += FinishedRecordEventHandler;
            _speechRecognition.StartedRecordEvent += StartedRecordEventHandler;
            _speechRecognition.RecordFailedEvent += RecordFailedEventHandler;

            _speechRecognition.BeginTalkigEvent += BeginTalkigEventHandler;
            _speechRecognition.EndTalkigEvent += EndTalkigEventHandler;

            //	_startRecordButton = transform.Find("Canvas/Button_StartRecord").GetComponent<Button>();
            //_startRecordButton = GameObject.Find("Button_StartRecord").GetComponent<Button>();



            //_speechRecognitionState = transform.Find("Canvas/Image_RecordState").GetComponent<Image>();

            //_resultText = transform.Find("Canvas/Panel_ContentResult/Text_Result").GetComponent<Text>();




            //_microphoneDevicesDropdown = transform.Find("Canvas/Dropdown_MicrophoneDevices").GetComponent<Dropdown>();

            //_contextPhrasesInputField = transform.Find("Canvas/InputField_SpeechContext").GetComponent<InputField>();


            //_voiceLevelImage = transform.Find("Canvas/Panel_VoiceLevel/Image_Level").GetComponent<Image>();

          //  _microphoneDevicesDropdown = transform.Find("Canvas/Dropdown_MicrophoneDevices").GetComponent<Dropdown>();
        
      
            _microphoneDevicesDropdown.onValueChanged.AddListener(MicrophoneDevicesDropdownOnValueChangedEventHandler);
     


            _microphoneDevicesDropdown.onValueChanged.AddListener(MicrophoneDevicesDropdownOnValueChangedEventHandler);

            _startRecordButton.interactable = true;
      
            _speechRecognitionState.color = Color.yellow;

       

            _microphoneDevicesDropdown.ClearOptions();

            for (int i = 0; i < _speechRecognition.GetMicrophoneDevices().Length; i++)
            {
                _microphoneDevicesDropdown.options.Add(new Dropdown.OptionData(_speechRecognition.GetMicrophoneDevices()[i]));
            }

            //smart fix of dropdowns
            _microphoneDevicesDropdown.value = 1;
            _microphoneDevicesDropdown.value = 0;
        }

        private void OnDestroy()
        {
            _speechRecognition.RecognizeSuccessEvent -= RecognizeSuccessEventHandler;
            _speechRecognition.RecognizeFailedEvent -= RecognizeFailedEventHandler;
            //_speechRecognition.LongRunningRecognizeSuccessEvent -= LongRunningRecognizeSuccessEventHandler;
            //_speechRecognition.LongRunningRecognizeFailedEvent -= LongRunningRecognizeFailedEventHandler;
            _speechRecognition.GetOperationSuccessEvent -= GetOperationSuccessEventHandler;
            _speechRecognition.GetOperationFailedEvent -= GetOperationFailedEventHandler;
            _speechRecognition.ListOperationsSuccessEvent -= ListOperationsSuccessEventHandler;
            _speechRecognition.ListOperationsFailedEvent -= ListOperationsFailedEventHandler;

            _speechRecognition.FinishedRecordEvent -= FinishedRecordEventHandler;
            _speechRecognition.StartedRecordEvent -= StartedRecordEventHandler;
            _speechRecognition.RecordFailedEvent -= RecordFailedEventHandler;

            _speechRecognition.EndTalkigEvent -= EndTalkigEventHandler;
        }

        private void Update()
        {
            if (SentenceMaker.sentenceMaker == null)
            {
                SentenceMaker.sentenceMaker = FindObjectOfType<SentenceMaker>();
            }

            if (SentenceMaker.sentenceMaker.isstartrecord)
            {

                SentenceMaker.sentenceMaker.startseconds -= Time.deltaTime;
                if (SentenceMaker.sentenceMaker.startseconds < 0)
                {
                    StartRecordButtonOnClickHandler();
                    SentenceMaker.sentenceMaker.isstartrecord = false;
                    //  SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[1];
                    // SentenceMaker.sentenceMaker.speechbubble.SetActive(false);
                    SentenceMaker.sentenceMaker.startseconds = 0;
                    Canrecord = true;
                    SentenceMaker.sentenceMaker.speechbubble.SetActive(false);
                    SentenceMaker.sentenceMaker. maxseconds = 3;
                }
            }

            if (Canrecord)
            {
             
                _startRecordButton.gameObject.SetActive(false);
                SentenceMaker.sentenceMaker.maxseconds -= Time.deltaTime;
                SentenceMaker.sentenceMaker.isrecorded = true;
                SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[1];
                if (SentenceMaker.sentenceMaker.maxseconds <= 0)
                {
                    SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[1];
                    Canrecord = false;
                   
                    SentenceMaker.sentenceMaker.isrecording = true;
                    SentenceMaker.sentenceMaker.maxseconds = 0;
                    SentenceMaker.sentenceMaker.isrecorded = false;
                   // _startRecordButton.gameObject.SetActive(true);

                    
                    StopRecordButtonOnClickHandler();
                }
              
            }
            _resultText.text.ToUpper();
            _contextPhrasesInputField.GetComponentInChildren<Text>().text = _resultText.text;
           
           
            SentenceMaker.sentenceMaker.voicetext.text =_resultText.text.ToUpper();
            //SentenceMaker.sentenceMaker.voicetext.text;
            SentenceMaker.sentenceMaker.voicetext.text=  SentenceMaker.sentenceMaker.voicetext.text.Trim();
            

                if (_speechRecognition.IsRecording)
                {
                if (_speechRecognition.GetMaxFrame() > 0)
                {
                    float max = (float)_speechRecognition.configs[_speechRecognition.currentConfigIndex].voiceDetectionThreshold;
                    float current = _speechRecognition.GetLastFrame() / max;

                    if (current >= 1f)
                    {
                        _voiceLevelImage.fillAmount = Mathf.Lerp(_voiceLevelImage.fillAmount, Mathf.Clamp(current / 2f, 0, 1f), 30 * Time.deltaTime);
                    }
                    else
                    {
                        _voiceLevelImage.fillAmount = Mathf.Lerp(_voiceLevelImage.fillAmount, Mathf.Clamp(current / 2f, 0, 0.5f), 30 * Time.deltaTime);
                    }

                    _voiceLevelImage.color = current >= 1f ? Color.green : Color.red;

                }
            }
            else
            {
                _voiceLevelImage.fillAmount = 0f;
            }
        }

        private void MicrophoneDevicesDropdownOnValueChangedEventHandler(int value)
        {
            if (!_speechRecognition.HasConnectedMicrophoneDevices())
                return;
            _speechRecognition.SetMicrophoneDevice(_speechRecognition.GetMicrophoneDevices()[value]);
        }

        public void StartRecordButtonOnClickHandler()
        {
            SentenceMaker.sentenceMaker.isrecording = false;
         //   Canrecord = true;
            SentenceMaker.sentenceMaker.isinstantiated = false;
            _resultText.text = string.Empty;

            _speechRecognition.StartRecord(false);
            SentenceMaker.sentenceMaker.alternativenames = new List<string>();
            SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[1];
            SentenceMaker.sentenceMaker.speechbubble.SetActive(false);
        }

        public void StopRecordButtonOnClickHandler()
        {

            //Canrecord = false;

            _startRecordButton.interactable = true;
         //   _startRecordButton.gameObject.SetActive(true);
            _speechRecognition.StopRecord();
            SentenceMaker.sentenceMaker.startseconds = 2f;

        }

   

        private void GetListOperationsButtonOnClickHandler()
        {
            // some parameters could be seted
            _speechRecognition.GetListOperations();
        }

        private void DetectThresholdButtonOnClickHandler()
        {
            _speechRecognition.DetectThreshold();
        }

        private void CancelAllRequetsButtonOnClickHandler()
        {
            _speechRecognition.CancelAllRequests();
        }

        private void RecognizeButtonOnClickHandler()
        {
            if (_speechRecognition.LastRecordedClip == null)
            {
                _resultText.text = "<color=red>No Record found</color>";
                return;
            }

            FinishedRecordEventHandler(_speechRecognition.LastRecordedClip);
        }

        private void StartedRecordEventHandler()
        {
            _speechRecognitionState.color = Color.green;
        }

        private void RecordFailedEventHandler()
        {
            _speechRecognitionState.color = Color.yellow;
            _resultText.text = "<color=red>Start record Failed. Please check microphone device and try again.</color>";

         
            _startRecordButton.interactable = true;
        }

        private void BeginTalkigEventHandler()
        {
            //_resultText.text = "<color=blue>Talk Began.</color>";
        }

        private void EndTalkigEventHandler(AudioClip clip)
        {
            //_resultText.text += "\n<color=blue>Talk Ended.</color>";

            FinishedRecordEventHandler(clip);
            SentenceMaker.sentenceMaker.isrecording = false;
        }

        private void FinishedRecordEventHandler(AudioClip clip)
        {
            if ( _startRecordButton.interactable)
            {
                _speechRecognitionState.color = Color.yellow;
            }

            if (clip == null/* || !_recognizeDirectlyToggle.isOn*/)
                return;

            RecognitionConfig config = RecognitionConfig.GetDefault();
            config.languageCode = Enumerators.LanguageCode.en_GB.Parse();
            config.speechContexts = new SpeechContext[]
            {
                new SpeechContext()
                {
                    phrases = _contextPhrasesInputField.text.Replace(" ", string.Empty).Split(',')
                }
            };
            config.audioChannelCount = clip.channels;
            // configure other parameters of the config if need

            GeneralRecognitionRequest recognitionRequest = new GeneralRecognitionRequest()
            {
                audio = new RecognitionAudioContent()
                {
                    content = clip.ToBase64()
                },
                //audio = new RecognitionAudioUri() // for Google Cloud Storage object
                //{
                //	uri = "gs://bucketName/object_name"
                //},
                config = config
            };


            _speechRecognition.Recognize(recognitionRequest);
        }

        private void GetOperationFailedEventHandler(string error)
        {
            _resultText.text = "Get Operation Failed: " + error;
        }

        private void ListOperationsFailedEventHandler(string error)
        {
            _resultText.text = "List Operations Failed: " + error;
        }

        private void RecognizeFailedEventHandler(string error)
        {
            _resultText.text = "Recognize Failed: " + error;
        }


        private void ListOperationsSuccessEventHandler(ListOperationsResponse operationsResponse)
        {
            //_resultText.text = "List Operations Success.\n";

            if (operationsResponse.operations != null)
            {
                //_resultText.text += "Operations:\n";

                foreach (var item in operationsResponse.operations)
                {
                    _resultText.text += item.name;
                //    _startRecordButton.gameObject.SetActive(true);
                }
            }
        }

        private void GetOperationSuccessEventHandler(Operation operation)
        {
            //	_resultText.text = "Get Operation Success.\n";
            _resultText.text += operation.name + operation.done;

            if (operation.done && (operation.error == null || string.IsNullOrEmpty(operation.error.message)))
            {
                InsertRecognitionResponseInfo(operation.response);
            }
        }

        private void RecognizeSuccessEventHandler(RecognitionResponse recognitionResponse)
        {
            //_resultText.text = "Recognize Success.";
            InsertRecognitionResponseInfo(recognitionResponse);
          
        }


        private void InsertRecognitionResponseInfo(RecognitionResponse recognitionResponse)
        {
            if (recognitionResponse == null || recognitionResponse.results.Length == 0)
            {
                _resultText.text = "Words not detected.";
                SentenceMaker.sentenceMaker.wordsnotdetected.text = "Words not detected.";
                Debug.Log("word");
                SentenceMaker.sentenceMaker.diyaobj.GetComponent<Image>().sprite = SentenceMaker.sentenceMaker.Diyasprite[2];
                SentenceMaker.sentenceMaker.speechbubble.SetActive(true);
                SentenceMaker.sentenceMaker.speechbubble.GetComponentInChildren<Text>().text = " I Could not understand." + "\n Please try again.";

             //   _startRecordButton.gameObject.SetActive(true);
                return;

            }

           

            var words = recognitionResponse.results[0].alternatives[0].words;

            if (words != null)
            {
                string times = string.Empty;

                foreach (var item in recognitionResponse.results[0].alternatives[0].words)
                {
                    times += /*"<color=green>" +*/item.word /*+ "</color> -  start: " + item.startTime + "; end: " + item.endTime + "\n"*/;
                }


                _resultText.text = times.Insert(times.Length, " ");
                if (!Canrecord)
                {
                    //   SentenceMaker.sentenceMaker   SentenceMaker.sentenceMaker.wordsnotdetected.text = "Words not detected.";.AddWord(SentenceMaker.sentenceMaker.voicetext.text);

                }
            }

            string other = "\nDetected alternatives: ";

            foreach (var result in recognitionResponse.results)
            {
                foreach (var alternative in result.alternatives)
                {
                    if (recognitionResponse.results[0].alternatives[0] != alternative)
                    {
                        SentenceMaker.sentenceMaker.alternativenames.Add(alternative.transcript.ToUpper());
                        other += alternative.transcript + ", ";
                       // _startRecordButton.gameObject.SetActive(true);
                    }
                }
            }

        //  _resultText.text += other;
           
        }




    }
   

}