using System;
using UnityEngine;

namespace CardPlay.Config {
    [Serializable]
    public class CardPlayConfig {
        [SerializeField]
        public RectTransform playArea;
        
        [SerializeField]
        public bool destroyOnPlay;

    }
}
