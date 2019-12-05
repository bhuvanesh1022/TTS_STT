using System;
using UnityEngine;
using UnityEngine.UI;

namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples
{
    public class STT_Test : MonoBehaviour
    {
        [SerializeField]private GCSpeechRecognition _speechReco;

        public Button _startBtn, _stopBtn;
        public Text _speechRecoResult;
        public Image _voiceLevelImage;

        // Start is called before the first frame update
        void Start()
        {
            _speechReco = GCSpeechRecognition.Instance;
            _speechReco.RecognizeSuccessEvent += RecognitionSuccessEventHandler;
            _speechReco.RecognizeFailedEvent += SpeechRecognitionFailedEventHandler;
            _speechReco.LongRunningRecognizeSuccessEvent += LongRecognitionSuccessEventHandler;

            _startBtn.interactable = true;
            _stopBtn.interactable = false;
        }

        private void OnDestroy()
        {
            _speechReco.RecognizeSuccessEvent -= RecognitionSuccessEventHandler;
            _speechReco.RecognizeFailedEvent -= SpeechRecognitionFailedEventHandler;
            _speechReco.LongRunningRecognizeSuccessEvent -= LongRecognitionSuccessEventHandler;
        }

        private void Update()
        {
            Debug.Log(_speechReco.IsRecording);

            if (_speechReco.IsRecording)
            {
                if (_speechReco.GetMaxFrame() > 0)
                {
                    float max = (float)_speechReco.configs[_speechReco.currentConfigIndex].voiceDetectionThreshold;
                    float current = _speechReco.GetLastFrame() / max;

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

        public void StartRecordEventHandler()
        {
            _startBtn.interactable = false;
            _stopBtn.interactable = true;
            _speechRecoResult.text = string.Empty;

            _speechReco.StartRecord(false);
        }

        public void StopRecordEventHandler()
        {
            _stopBtn.interactable = false;
            _startBtn.interactable = true;

            _speechReco.StopRecord();
        }

        private void RecognitionSuccessEventHandler(RecognitionResponse obj)
        {
            Debug.Log("SpeecghRecognized");

            InsertRecognitionResponseInfo(obj);
            _startBtn.interactable = true;
        }

        private void SpeechRecognitionFailedEventHandler(string obj)
        {
            _speechRecoResult.text = "Speech Recognition Failed : " + obj;

            //_startBtn.interactable = true;
            //_stopBtn.interactable = false;
        }

        private void InsertRecognitionResponseInfo(RecognitionResponse recognitionResponse)
        {
            if (recognitionResponse == null || recognitionResponse.results.Length == 0)
            {
                _speechRecoResult.text = "\nWords not detected.";
                return;
            }

            _speechRecoResult.text += "\n" + recognitionResponse.results[0].alternatives[0].transcript;

            var words = recognitionResponse.results[0].alternatives[0].words;

            if (words != null)
            {
                string times = string.Empty;

                foreach (var item in recognitionResponse.results[0].alternatives[0].words)
                {
                    times += "<color=green>" + item.word + "</color> -  start: " + item.startTime + "; end: " + item.endTime + "\n";
                }

                _speechRecoResult.text += "\n" + times;
            }

            string other = "\nDetected alternatives: ";

            foreach (var result in recognitionResponse.results)
            {
                foreach (var alternative in result.alternatives)
                {
                    if (recognitionResponse.results[0].alternatives[0] != alternative)
                    {
                        other += alternative.transcript + ", ";
                    }
                }
            }

            _speechRecoResult.text += other;
        }

        private void LongRecognitionSuccessEventHandler(Operation obj)
        {

        }
    }
}

