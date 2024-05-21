using UnityEngine;

namespace LoveAndLogos.Events
{
    public class PlayableCardHover : MonoBehaviour {
        public readonly CardType cardType;
        public PlayableCardHover(CardType cardType)
        {
            this.cardType = cardType;
        }
    }
}