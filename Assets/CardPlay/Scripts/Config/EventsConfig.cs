using System;
using CardPlay.Events;
using UnityEngine;
using UnityEngine.Events;

namespace CardPlay.Config {
    [Serializable]
    public class EventsConfig {
        [SerializeField]
        public UnityEvent<CardPlayed> OnCardPlayed;
        
        [SerializeField]
        public UnityEvent<CardHover> OnCardHover;
        
        [SerializeField]
        public UnityEvent<CardUnhover> OnCardUnhover;
        
        [SerializeField]
        public UnityEvent<CardDestroy> OnCardDestroy;
    }
}
