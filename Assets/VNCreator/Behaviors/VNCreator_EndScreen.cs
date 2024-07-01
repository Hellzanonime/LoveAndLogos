using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_EndScreen : MonoBehaviour
    {
        public Button restartButton;
        public Button nextChapterButton;
        public Button mainMenuButton;
        [Scene]
        public string mainMenu;
        public string nextChapter;
        [SerializeField]
        private GameObject MainStuff;

        void Start()
        {
            restartButton.onClick.AddListener(Restart);
            nextChapterButton.onClick.AddListener(NextChapter);
            mainMenuButton.onClick.AddListener(MainMenu);
            MainStuff.SetActive(false);
        }

        void Restart()
        {
            GameSaveManager.NewLoad("MainGame");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        void NextChapter()
        {
            SceneManager.LoadScene(nextChapter, LoadSceneMode.Single);
        }
        void MainMenu()
        {
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}
