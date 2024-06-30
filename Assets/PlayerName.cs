using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerName : MonoBehaviour
{
    [SerializeField]
    private string playerHolder;
    
    [SerializeField]
    private Text dialogueText, characterNamesTxt;
    [SerializeField]
    private string scenename;
    // PlayerPseudo
    // PseudoChanged
    // DialogueNameChanged

    private void Awake()
    {
        scenename = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        characterNamesTxt = GameObject.Find("NameText").GetComponent <Text>();
        playerHolder = PlayerPrefs.GetString("PlayerPseudo");
    }

    private void UpdateDialogueBox()
    {
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        characterNamesTxt = GameObject.Find("NameText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterNamesTxt.text.Contains("XXX") && PlayerPrefs.GetInt("PseudoChanged") == 0)
        {
            //Debug.Log("XXX name trouver");            
            characterNamesTxt.text = characterNamesTxt.text.Replace("XXX", playerHolder);
            PlayerPrefs.SetInt("PseudoChanged", 1);
        }
        if (dialogueText.text.Contains("XXX") && PlayerPrefs.GetInt("DialogueNameChanged") == 0)
        {
            //Debug.Log("XXX trouver");            
            dialogueText.text = dialogueText.text.Replace("XXX", playerHolder);
            StartCoroutine(WaitTimeDialogueupdate());
        }
        if (scenename != SceneManager.GetActiveScene().name)
        {
            scenename = SceneManager.GetActiveScene().name;
            UpdateDialogueBox();
        }
    }

    IEnumerator WaitTimeDialogueupdate()
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("DialogueNameChanged", 1);
    }
}
