using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


namespace LoveAndLogos
{
    public class NewStory : MonoBehaviour
    {
        [SerializeField] 
        private string sceneName;
        [SerializeField]
        private GameObject optionUI, nametacker;
        [SerializeField]
        private TMP_InputField inputField;

        private void Awake()
        {
            PlayerPrefs.SetInt("MusicTrack", 0);
        }

        public void SavePlayerName()
        {
            PlayerPrefs.SetString("PlayerPseudo", inputField.text);
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void OpenOptions()
        {
            optionUI.SetActive(true);
            nametacker.SetActive(false);
        }
    }
}
