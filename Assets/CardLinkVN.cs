using CardPlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;
using CardPlay;
using UnityEngine.UI;

namespace LoveAndLogos
{
    public class CardLinkVN : MonoBehaviour
    {
        [SerializeField]
        private VNCreator_DisplayUI vnManager;
        private GameObject holder, holder2;
        [SerializeField]
        private CardContainer cc;
        [SerializeField]
        private CardDeckManager cardManager;
        [SerializeField]
        private CardType cardType;
        private int cardNature;
        [SerializeField]
        private GameObject cardPlayarena;
        [SerializeField]
        private bool isHover = true;
        [SerializeField]
        private Text hoverTxt;
        [SerializeField]
        private List<CardType> cardTypes;
        
        public void DrawCard()
        {
            if (vnManager.nbsOfChoices == 2)
            {
                cardManager.DrawCardCollection(cardTypes);
                cardPlayarena.SetActive(true);
            }
            else
            {
                cardManager.DrawEveryCardType();
                cardPlayarena.SetActive(true);
            }
        }
        private void Update()
        {
            // if player is hovering card
            if (PlayerPrefs.GetInt("HoverCard") == 1 && isHover)
            {
                StartCoroutine(CardHoverText());
            }
        }

        public void TestingHoverCard()
        {
            StartCoroutine(CardHoverText());
        }

        IEnumerator CardHoverText()
        {
            isHover = false;
            //Debug.Log("hover = 1");
            ////send pas choices infos to crard player thingy 
            cardNature = PlayerPrefs.GetInt("CardNature");
            cardManager.choiceTxt = vnManager.choicesTxt[cardNature];
            if (cardNature == 0)
            {
                cardType = CardType.Neutral;
            }
            else if (cardNature == 1)
            {
                cardType = CardType.Friendly;
            }
            else
            {
                cardType = CardType.Hostile;
            }
            cardManager.ShowHoveringDescription(cardType);
            //Debug.Log("choice text : " + cardManager.choiceTxt);
            yield return new WaitForSeconds(1f);
            isHover = true;
        }

        public void CardPlayed()
        {
            StartCoroutine(CardsPlaying());
        }

        IEnumerator CardsPlaying()
        {
            cardPlayarena.SetActive(false);
            yield return new WaitForSeconds(1f);
            //check name of game object 
            //if 1 found calle node choice 0
            //ect
            if (vnManager.nbsOfChoices == 3)
            {
                if (GameObject.Find("CardDialogueNeutral(Clone)") == null)
                {
                    //Debug.Log("didnt finf neutral card");
                    holder = GameObject.Find("CardDialogueFriendly(Clone)");
                    holder2 = GameObject.Find("CardDialogueHostile(Clone)");
                    cc.DestroyCard(holder.GetComponent<CardWrapper>());
                    cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                    hoverTxt.text = " ";
                    vnManager.PlayNextNode(0);
                }
                else if (GameObject.Find("CardDialogueFriendly(Clone)") == null)
                {
                    //Debug.Log("didnt finf friendly card");
                    holder = GameObject.Find("CardDialogueNeutral(Clone)");
                    holder2 = GameObject.Find("CardDialogueHostile(Clone)");
                    cc.DestroyCard(holder.GetComponent<CardWrapper>());
                    cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                    hoverTxt.text = " ";
                    vnManager.PlayNextNode(1);
                }
                else
                {
                    //Debug.Log("didnt finf evil card");
                    holder = GameObject.Find("CardDialogueNeutral(Clone)");
                    holder2 = GameObject.Find("CardDialogueFriendly(Clone)");
                    cc.DestroyCard(holder.GetComponent<CardWrapper>());
                    cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                    hoverTxt.text = " ";
                    vnManager.PlayNextNode(2);
                }
            }
            else
            {
                if (GameObject.Find("CardDialogueNeutral(Clone)") == null)
                {
                    //Debug.Log("didnt finf neutral card");
                    holder = GameObject.Find("CardDialogueFriendly(Clone)");
                    cc.DestroyCard(holder.GetComponent<CardWrapper>());
                    hoverTxt.text = " ";
                    vnManager.PlayNextNode(0);
                }
                else 
                {
                    //Debug.Log("didnt finf friendly card");
                    holder = GameObject.Find("CardDialogueNeutral(Clone)");
                    cc.DestroyCard(holder.GetComponent<CardWrapper>());
                    hoverTxt.text = " ";
                    vnManager.PlayNextNode(1);
                }
            }
            
        }
    }
}
