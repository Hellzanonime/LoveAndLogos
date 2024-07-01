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
    private Text dialogueText, characterNamesTxt, hoverTxt;
    [SerializeField]
    private string scenename;
    // PlayerPseudo
    // PseudoChanged
    // DialogueNameChanged

    private void Awake()
    {
        scenename = SceneManager.GetActiveScene().name;
        //DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHolder = PlayerPrefs.GetString("PlayerPseudo");
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
        if (hoverTxt.text.Contains("XXX") && PlayerPrefs.GetInt("HoverChanged") == 0)
        {
            hoverTxt.text = hoverTxt.text.Replace("XXX", playerHolder);
        }
    }

    IEnumerator WaitTimeDialogueupdate()
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("DialogueNameChanged", 1);
    }
}
