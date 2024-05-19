using CardPlay.Events;
using UnityEngine;

namespace CardPlay.Demo {
    public class CardDestroyer : MonoBehaviour {
        public CardContainer container;
        public void OnCardDestroyed(CardPlayed evt) {
            container.DestroyCard(evt.card);
        }
    }
}
