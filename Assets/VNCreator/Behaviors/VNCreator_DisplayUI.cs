using System.Collections;
using System.Collections.Generic;
using LoveAndLogos;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_DisplayUI : DisplayBase
    {
        [Header("Text")]
        public Text characterNameTxt;
        public Text dialogueTxt;
        [Header("Visuals")]
        public Image characterImg;
        public Image backgroundImg;
        [Header("Audio")]
        public AudioSource musicSource;
        public AudioSource soundEffectSource;
        [Header("Buttons")]
        public Button nextBtn;
        public Button previousBtn;
        public Button saveBtn;
        public Button endSaveBtn;
        public Button menuButton;
        [Header("Choices")]
        public Button choiceBtn1;
        public Button choiceBtn2;
        public Button choiceBtn3;
        //modif here
        [Header("Card stuff")]
        public Button cardBtn;
        public GameObject Cards;
        [SerializeField]
        private Text hoverTxt;
        [Header("Sounds stuff")]
        public VNCreator_SfxSource vnSFX;
        [Header("les choice text")]
        public string[] choicesTxt;
        public int nbsOfChoices;
        //public VNCreator_MusicSource vnMusic;
        //end modif
        [Header("End")]
        public GameObject endScreen;
        [Header("Main menu")]
        [Scene]
        public string mainMenu;

        void Start()
        {
            nextBtn.onClick.AddListener(delegate { NextNode(0); });
            if(previousBtn != null)
                previousBtn.onClick.AddListener(Previous);
            if(saveBtn != null)
                saveBtn.onClick.AddListener(Save);
            if (menuButton != null)
                menuButton.onClick.AddListener(ExitGame);
            if(endSaveBtn != null)
                endSaveBtn.onClick.AddListener(Save);
            if(choiceBtn1 != null)
                choiceBtn1.onClick.AddListener(delegate { NextNode(0); });
            if(choiceBtn2 != null)
                choiceBtn2.onClick.AddListener(delegate { NextNode(1); });
            if(choiceBtn3 != null)
                choiceBtn3.onClick.AddListener(delegate { NextNode(2); });

            endScreen.SetActive(false);
            //modif here
            /*choicesTxt[0] = " ";
            choicesTxt[1] = " ";
            choicesTxt[2] = " ";*/
            //end modif 
            StartCoroutine(DisplayCurrentNode());
        }

        public void PlayNextNode(int nodeID)
        {
            if (lastNode)
            {
                endScreen.SetActive(true);
                return;
            }

            base.NextNode(nodeID);
            //Debug.Log("le num du choix de la node : " + nodeID);
            StartCoroutine(DisplayCurrentNode());
        }

        protected override void NextNode(int _choiceId)
        {
            if (lastNode)
            {
                endScreen.SetActive(true);
                return;
            }

            base.NextNode(_choiceId);
            StartCoroutine(DisplayCurrentNode());
        }

        IEnumerator DisplayCurrentNode()
        {
            //Debug.Log("displ current node : " + currentNode.dialogueText);
            nbsOfChoices = currentNode.choices;
            characterNameTxt.text = currentNode.characterName;
            if (currentNode.characterSpr != null)
            {
                characterImg.sprite = currentNode.characterSpr;
                characterImg.color = Color.white;
            }
            else
            {
                characterImg.color = new Color(1, 1, 1, 0);
            }
            if(currentNode.backgroundSpr != null)
                backgroundImg.sprite = currentNode.backgroundSpr;

            if (currentNode.choices <= 1) 
            {
                nextBtn.gameObject.SetActive(true);
                // modif here
                cardBtn.gameObject.SetActive(false);
                Cards.SetActive(false);
                //saveBtn.gameObject.SetActive(true);
                //menuButton.gameObject.SetActive(true);
                // end motif
                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                choiceBtn3.gameObject.SetActive(false);

                previousBtn.gameObject.SetActive(loadList.Count != 1);
            }
            else
            {
                nextBtn.gameObject.SetActive(false);
                // modif here
                cardBtn.gameObject.SetActive(true);
                Cards.SetActive(true );
                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                //modif here 
                choicesTxt[0] = currentNode.choiceOptions[0];
                choicesTxt[1] = currentNode.choiceOptions[1];
                //end modif 
                //saveBtn.gameObject .SetActive(false);
                //menuButton.gameObject.SetActive(false);
                // end motif
                /*choiceBtn1.gameObject.SetActive(true);
                choiceBtn1.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[0];

                choiceBtn2.gameObject.SetActive(true);
                choiceBtn2.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[1];*/

                if (currentNode.choices == 3)
                {
                    // modif here
                    //modif here 
                    choicesTxt[0] = currentNode.choiceOptions[0];
                    choicesTxt[1] = currentNode.choiceOptions[1];
                    choicesTxt[2] = currentNode.choiceOptions[2];
                    //end modif 
                    cardBtn.gameObject.SetActive(true);
                    Cards.SetActive(true ) ;
                    choiceBtn1.gameObject.SetActive(false);
                    choiceBtn2.gameObject.SetActive(false);
                    choiceBtn3.gameObject.SetActive(false);
                    //saveBtn.gameObject.SetActive(false);
                    //menuButton.gameObject.SetActive(false);
                    // end motif
                    /*choiceBtn3.gameObject.SetActive(true);
                    choiceBtn3.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[2];*/
                }
                else
                {
                    choiceBtn3.gameObject.SetActive(false);
                }
            }
            //modife here
            /*if (currentNode.backgroundMusic != null)
            {
                vnMusic.PlayMusicClip(currentNode.backgroundMusic);
            }*/
                //VNCreator_MusicSource.instance.Play(currentNode.backgroundMusic); */
            if (currentNode.soundEffect != null)
            {
                //soundEffectSource.PlayOneShot(currentNode.soundEffect);
                vnSFX.PlayClip(currentNode.soundEffect);
            }
                //VNCreator_SfxSource.instance.Play(currentNode.soundEffect);
            //end modif 
            dialogueTxt.text = string.Empty;
            if (GameOptions.isInstantText)
            {
                dialogueTxt.text = currentNode.dialogueText;
            }
            else
            {
                char[] _chars = currentNode.dialogueText.ToCharArray();
                string fullString = string.Empty;
                for (int i = 0; i < _chars.Length; i++)
                {
                    fullString += _chars[i];
                    dialogueTxt.text = fullString;
                    yield return new WaitForSeconds(0.01f/ GameOptions.readSpeed);
                }
            }
        }

        protected override void Previous()
        {
            base.Previous();
            StartCoroutine(DisplayCurrentNode());
        }

        void ExitGame()
        {
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}