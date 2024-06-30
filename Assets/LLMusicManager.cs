using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using VNCreator;

namespace LoveAndLogos
{
    public class LLMusicManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource introSource, loopSource;
        private int j;
        [SerializeField]
        private VNCreator_DisplayUI vnSys;
        [Header("Musics Intros")]
        public AudioClip[] intros;
        [Header("Musics Loops")]
        public AudioClip[] loops;
        [Header("Musical Cues")]
        public string[] musicTxt;
        public bool musicChanged = false;
        //private StoryObject storyManager;
        private void Awake()
        {
            introSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            loopSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            StartCoroutine(LoopingTrack());            
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < musicTxt.Length; i++)
            {
                if (vnSys.dialogueTxt.text == musicTxt[i] && !musicChanged)
                {
                    j = PlayerPrefs.GetInt("MusicTrack");
                    if(j < musicTxt.Length-1)
                    {
                        j++;
                        PlayerPrefs.SetInt("MusicTrack", j);
                        ChangeTrack();
                    }                
                }
            }
            
        }

        void ChangeTrack()
        {
            musicChanged = true;
            StartCoroutine(LoopingTrack());
        }

        IEnumerator ChangingTrack()
        {
            introSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            introSource.clip = intros[j];
            introSource.Play();
            yield return new WaitForSeconds(intros[j].length);
            musicChanged = false;
            Debug.Log("le text ref = le text dialogue");
        }

        IEnumerator LoopingTrack()
        {
            introSource.clip = intros[j];
            loopSource.Stop();
            introSource.Play();
            yield return new WaitForSeconds(intros[j].length);
            loopSource.clip = loops[j];
            loopSource.loop = true;
            loopSource.Play();
            musicChanged = false;
        }
    }
}
