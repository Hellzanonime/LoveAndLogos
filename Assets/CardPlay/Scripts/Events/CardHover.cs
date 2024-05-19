namespace CardPlay.Events {
    public class CardHover : CardPlayed {
        public CardHover(CardWrapper card) : base(card) {
        }
    }
}
