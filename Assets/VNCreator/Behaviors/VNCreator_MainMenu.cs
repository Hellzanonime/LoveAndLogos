using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        public Button newGameBtn;
        public Button continueBtn;
        public Button optionsMenuBtn;
        public Button quitBtn;

        [Header("")]
        [Scene]
        public string playScene, chapter1;

        [Header("Menu Objects")]
        public GameObject optionsMenu;
        public GameObject mainMenu;

        void Start()
        {
            if(newGameBtn != null)
                newGameBtn.onClick.AddListener(NewGame);
            if(optionsMenuBtn != null)
                optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);
            if(quitBtn != null)
                quitBtn.onClick.AddListener(Quit);
            if (continueBtn != null)
            {
                if (PlayerPrefs.HasKey("MainGame"))
                    continueBtn.onClick.AddListener(LoadGame);
                else
                    continueBtn.interactable = false;
            }            
        }

        void NewGame()
        {
            GameSaveManager.NewLoad("MainGame");
            SceneManager.LoadScene("LL_Player", LoadSceneMode.Single);
        }

        void LoadGame()
        {
            if (GameObject.Find("SceneTraces"))
            {
                GameSaveManager.currentLoadName = "MainGame2";
                SceneManager.LoadScene(chapter1, LoadSceneMode.Single);
            }
            else
            {
                GameSaveManager.currentLoadName = "MainGame";
                SceneManager.LoadScene(playScene, LoadSceneMode.Single);
            }
            
        }

        void DisplayOptionsMenu()
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        void Quit()
        {
            Application.Quit();
        }
    }
}
