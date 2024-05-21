using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LoveAndLogos
{
    // Serializer for editor scripting
    [Serializable]
    public class CardTypeSerializer
    {
        [SerializeField] public CardType cardType;
        [SerializeField] public GameObject prefab;
    }
    
    public class CardDeckManager : MonoBehaviour
    {

        // Exposed properties
        [Header("Scene objects")] 
        [SerializeField]
        private GameObject cardContainer;
        
        // Private initialized fields
        [Header("Properties")] 
        [SerializeField] 
        private List<CardTypeSerializer> cardPrefabs;
        private Dictionary<CardType, GameObject> _cartTypeObjectMap;

        private void Start()
        {
            // Fill the type-prefab dictionnary for card objects
            _cartTypeObjectMap = new Dictionary<CardType, GameObject>();
            foreach (var cts in cardPrefabs)
            {
                _cartTypeObjectMap.Add(cts.cardType, cts.prefab);
            }

        }

        /*
         * Draw an instance of a card corresponding to a card type
         * @param CardType cardType the type of the card that will be drawn
         */
        private void _DrawCardFromType(CardType cardType)
        {
            var card = Instantiate(_cartTypeObjectMap[cardType], new Vector3(0, 0, 0), Quaternion.identity);
            card.transform.parent = cardContainer.transform;
        }

        /*
         * Draw an instance of each card type in a list
         * Accepts duplicate card types
         * @param List<CardType> cardTypes a list of ordered card types
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
    }
}
