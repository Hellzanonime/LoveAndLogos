namespace CardPlay.Events {
    public class CardUnhover : CardEvent {
        public CardUnhover(CardWrapper card) : base(card) {
        }
    }
}
