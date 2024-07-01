using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    [RequireComponent(typeof(AudioSource))]
    public class VNCreator_SfxSource : MonoBehaviour
    {
        AudioSource source;

        public static VNCreator_SfxSource instance;

        void Awake()
        {
            instance = this;
            source = GetComponent<AudioSource>();
            source.playOnAwake = false;
            source.volume = GameOptions.sfxVolume;
        }

        public void PlayClip(AudioClip clip)//adde Clip after Play
        {
            source.clip = clip;
            source.Play();
        }
    }
}
