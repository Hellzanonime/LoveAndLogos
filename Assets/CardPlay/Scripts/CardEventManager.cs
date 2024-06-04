using System;
using CardPlay.Events;
using LoveAndLogos;
using UnityEngine;

namespace CardPlay
{
    public class CardEventManager : MonoBehaviour
    {
        private CardDeckManager cardDeckManager;

        public void Awake()
        {
            cardDeckManager = GetComponent<CardDeckManager>();
        }

        public void OnCardHover(CardHover cardHover) {
            cardDeckManager.ShowHoveringDescription(cardHover.card.playableCard.cardType);
        }
        
        public void OnCardUnhover() {
            cardDeckManager.HideHoveringDescription();
        }
    }
}