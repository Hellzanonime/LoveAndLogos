using CardPlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;
using CardPlay;

namespace LoveAndLogos
{
    public class CardLinkVN : MonoBehaviour
    {
        [SerializeField]
        private VNCreator_DisplayUI vnManager;
        private GameObject holder, holder2;
        [SerializeField]
        private CardContainer cc;

        public void CardPlayed() 
        {
            StartCoroutine(CardsPlaying());
        }

        IEnumerator CardsPlaying()
        {
            yield return new WaitForSeconds(1f);
            //check name of game object 
            //if 1 found calle node choice 0
            //ect
            if (GameObject.Find("CardDialogueNeutral(Clone)") == null)
            {
                Debug.Log("didnt finf neutral card");
                holder = GameObject.Find("CardDialogueFriendly(Clone)");
                holder2 = GameObject.Find("CardDialogueHostile(Clone)");
                cc.DestroyCard(holder.GetComponent<CardWrapper>());
                cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                vnManager.PlayNextNode(0);
            }
            else if (GameObject.Find("CardDialogueFriendly(Clone)") == null)
            {
                Debug.Log("didnt finf friendly card");
                holder = GameObject.Find("CardDialogueNeutral(Clone)");
                holder2 = GameObject.Find("CardDialogueHostile(Clone)");
                cc.DestroyCard(holder.GetComponent<CardWrapper>());
                cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                vnManager.PlayNextNode(1);
            }
            else
            {
                Debug.Log("didnt finf evil card");
                holder = GameObject.Find("CardDialogueNeutral(Clone)");
                holder2 = GameObject.Find("CardDialogueFriendly(Clone)");
                cc.DestroyCard(holder.GetComponent<CardWrapper>());
                cc.DestroyCard(holder2.GetComponent<CardWrapper>());
                vnManager.PlayNextNode(2);
            }
        }
    }
}
