using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_OptionsMenu : MonoBehaviour
    {
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;
        public Slider readSpeedSlider;
        public Toggle instantTextToggle;
        public Button backButton;

        [Header("Menu Objects")]
        public GameObject optionsMenu;
        public GameObject mainMenu;

        //modif here
        [SerializeField]
        private AudioSource musicSource;
        //end modif 

        void Start()
        {
            GameOptions.InitilizeOptions();
            UpdateMusicVilMM();
            if(musicVolumeSlider != null)
            {
                musicVolumeSlider.value = GameOptions.musicVolume;
                musicVolumeSlider.onValueChanged.AddListener(GameOptions.SetMusicVolume);
                //modif here | change vokume of main menu music in real time
                musicVolumeSlider.onValueChanged.AddListener(delegate { UpdateMusicVilMM(); });
                //end modif
            }
            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = GameOptions.sfxVolume;
                sfxVolumeSlider.onValueChanged.AddListener(GameOptions.SetSFXVolume);
            }
            if (readSpeedSlider != null)
            {
                readSpeedSlider.value = GameOptions.readSpeed;
                readSpeedSlider.onValueChanged.AddListener(GameOptions.SetReadingSpeed);
            }
            if (instantTextToggle != null)
            {
                instantTextToggle.isOn = GameOptions.isInstantText;
                instantTextToggle.onValueChanged.AddListener(GameOptions.SetInstantText);
            }

            backButton.onClick.AddListener(Back);
        }
        //modif here | change vokume of main menu music in real time 
        private void UpdateMusicVilMM()
        {
            musicSource.volume = GameOptions.musicVolume;
        }
        //end modif
        void Back()
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }
}
