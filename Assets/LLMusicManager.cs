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
        private AudioSource musicsource;
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
        [SerializeField]
        private string leTxt;
        private int holder;
        //private StoryObject storyManager;
        private void Awake()
        {
            musicsource.volume = PlayerPrefs.GetFloat("MusicVolume");
            j = PlayerPrefs.GetInt("MusicTrack");
            StartCoroutine(LoopingTrack());            
        }

        // Update is called once per frame
        void Update()
        {
            if(holder <= musicTxt.Length)
            {
                Debug.Log("holder : " + holder);
                for (int i = holder; i < musicTxt.Length; i++)
                {
                    //Debug.Log(" for text : " + vnSys.dialogueTxt.text + "j : " + j);
                    leTxt = vnSys.dialogueTxt.text;
                    if (/*vnSys.dialogueTxt.text == musicTxt[i]*/ vnSys.dialogueTxt.text.Contains(musicTxt[i]) && !musicChanged)
                    {
                        j = PlayerPrefs.GetInt("MusicTrack");
                        holder++;
                        //Debug.Log("text : " + vnSys.dialogueTxt.text + "j : " + j);
                        if (j < musicTxt.Length)
                        {
                            j++;
                            PlayerPrefs.SetInt("MusicTrack", j);
                            ChangeTrack();
                        }
                    }
                    else
                    {
                        //musicChanged = false;
                        return;
                    }
                }
            }         
            
        }

        void ChangeTrack()
        {
            StartCoroutine(LoopingTrack());
            StartCoroutine(ChangingBool());
            musicChanged = true;
        }
        IEnumerator ChangingBool()
        {
            yield return new WaitForSeconds(15f);
            musicChanged = false;
        }

        IEnumerator LoopingTrack()
        {
            musicsource.clip = intros[j];
            musicsource.loop = false;
            musicsource.Play();
            yield return new WaitForSeconds(intros[j].length);
            musicsource.clip = loops[j];
            musicsource.loop = true;
            musicsource.Play();
        }
    }
}
