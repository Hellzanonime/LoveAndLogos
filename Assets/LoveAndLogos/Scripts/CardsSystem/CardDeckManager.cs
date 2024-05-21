using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using AYellowpaper.SerializedCollections;
using LoveAndLogos.Events;
// Uncomment or delete this when assembly definitions are fixed
/*using CardPlay;
using CardPlay.Events;*/

namespace LoveAndLogos
{
    public class CardDeckManager : MonoBehaviour
    {

        // Exposed properties
        [Header("Scene objects")] 
        [SerializeField] private GameObject cardContainer;
        [SerializeField] private GameObject hoveringDescriptionBox;
        [SerializeField] private Text hoveringDescriptionText;
        
        [Header("Properties")] 
        [SerializedDictionary("Card Type", "Prefab")]
        public SerializedDictionary<CardType, GameObject> cardTypeObjectMap;

        /*
         * Draw an instance of a card corresponding to a card type
         * @param   CardType    cardType    the type of the card that will be drawn
         */
        private void _DrawCardFromType(CardType cardType)
        {
            var card = Instantiate(cardTypeObjectMap[cardType], new Vector3(0, 0, 0), Quaternion.identity);
            card.transform.parent = cardContainer.transform;
        }

        /*
         * Draw an instance of each card type in a list
         * Accepts duplicate card types (both will have save dialog description)
         * @param   List<CardType>  cardTypes   a list of ordered card types
         */
        public void DrawCardCollection(List<CardType> cardTypes)
        {
            foreach (var cardType in cardTypes)
            {
                _DrawCardFromType(cardType);
            }
        }

        /*
         * Draw an unique instance of each card type
         */
        public void DrawEveryCardType()
        {
            DrawCardCollection(new List<CardType>(Enum.GetValues(typeof(CardType)).Cast<CardType>()));
        }

        /*
         * Get a description of the selected card, obtained from the card type and the current VN dialog
         * @param   CardType    cardType    the type of the card hovered in hand
         * @return  String                  the description associated with the card type
         */
        private String _GetDescription(CardType cardType)
        {
            // TODO
            return
                "Placeholder description with card text. Will get extracted from the CardType + Context combination in the future";
        }
        
        // Uncomment this when CardPlay.Events.CardHover becomes accessible
        /*public void OnCardHover(CardHover cardHover) {
            print(cardHover);
            ShowHoveringDescription(cardHover);
        }*/
        
        public void OnCardUnhover() {
            HideHoveringDescription();
        }
        
        /*
         * Show a small text of what the card description is in this context
         * @param   int    indexInHand    the index of the hovered card in hand, from left to right, including 0
         */
        public void ShowHoveringDescription(PlayableCardHover cardHover)
        {
            var cardType = cardHover.cardType;
            var description = _GetDescription(cardType);
            
            // hoveringDescriptionText [should be equal to] hoveringDescriptionBox.transform.GetChild(0).gameObject.GetComponent<Text>()
            // Maybe use it in the future if we plan to reduce serialized objects
            hoveringDescriptionText.text = description;
            
            hoveringDescriptionBox.gameObject.SetActive(true);
        }

        /*
         * Hide the hovering card description
         */
        public void HideHoveringDescription()
        {
            hoveringDescriptionBox.gameObject.SetActive(false);
        }
        
    }
}
