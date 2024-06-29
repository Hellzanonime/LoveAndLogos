using System;
using System.Collections;
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
            if (Application.platform == RuntimePlatform.Android)
            {
                //deactivat this when on phone it's bugging with the dragging 
            }
            else
            {
                Debug.Log(((int)cardHover.card.playableCard.cardType));
                PlayerPrefs.SetInt("HoverCard", 1);
                PlayerPrefs.SetInt("CardNature", ((int)cardHover.card.playableCard.cardType));
            }            
            //cardDeckManager.ShowHoveringDescription(cardHover.card.playableCard.cardType);
        }
        
        public void OnCardUnhover() {
            if(Application.platform == RuntimePlatform.Android)
            {
                //debuging the draggin phone
            }
            else
            {
                PlayerPrefs.SetInt("HoverCard", 0);
                PlayerPrefs.SetInt("CardNature", 0);
                cardDeckManager.HideHoveringDescription();
            }
            
        }
    }
}