using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.Collections;
using UnityEngine;

namespace LoveAndLogos
{
    public class AffinitySystem : MonoBehaviour
    {
        private static AffinitySystem instance = null;
        public static AffinitySystem GetInstance() => instance;

        [SerializedDictionary("Love Interrest", "Score"), ReadOnly]
        public SerializedDictionary<LoveInterests, int> affinityScores; 
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                InitializeAffinityScores();
                instance = this;
                DontDestroyOnLoad(this);
            }
        }
        public static void UpdateAffinity(LoveInterests loveInterest, int amount)
        {
            var affinitySystemInstance = GetInstance();
            if (affinitySystemInstance)
            {
                if (affinitySystemInstance.affinityScores.ContainsKey(loveInterest))
                {
                    affinitySystemInstance.affinityScores[loveInterest] += amount;
                }
            }
        }

        public static int GetAffinity(LoveInterests loveInterest)
        {
            var affinitySystemInstance = GetInstance();
            if (affinitySystemInstance)
            {
                if (affinitySystemInstance.affinityScores.TryGetValue(loveInterest, out var affinity))
                {
                    return affinity;
                }
            }

            Debug.LogError("Can't find key : " + loveInterest);
            return -1;
        }

        private void InitializeAffinityScores()
        {
            // Initialize affinity scores
            affinityScores = new SerializedDictionary<LoveInterests, int>()
            {
                { LoveInterests.Plato, 0},
                { LoveInterests.Alexander , 0}
            };
        }
    }
}
