using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;
using UnityEngine.UI;
using TMPro;


public class DiceRollsManager : MonoBehaviour
{
    [SerializeField] 
    private VNCreator_DisplayUI vnManag;
    [SerializeField]
    private Text characterNamesTxt;
    [SerializeField]
    private TMP_Text diceTxt1,diceTxt2;
    [SerializeField]
    private GameObject dicesetUp, fatesBtn,mainTxt, diceAnim, diceImg,acceptSBtn, acceptFBtn;
    [SerializeField]
    private int dice1,dice2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterNamesTxt.text.Contains("DR") && PlayerPrefs.GetInt("DiceRollActivated") == 0)
        {
            //Debug.Log("XXX name trouver");
            dicesetUp.SetActive(true);
            characterNamesTxt.text = characterNamesTxt.text.Replace("DR", "Good luck");
            LaunchDiceRolls();
            PlayerPrefs.SetInt("DiceRollActivated", 1);
        }
    }

    void LaunchDiceRolls()
    {
        //hide old ui
        fatesBtn.SetActive(false);
        //mainTxt.SetActive(false);
        diceTxt1.text = " ";
        diceTxt2.text = " ";
        //show dice rolls animation 
        diceAnim.SetActive(true);
        diceImg.SetActive(true);
        //wait a few 
        StartCoroutine(WaitForResDice());
        
    }

    IEnumerator WaitForResDice()
    {
        yield return new WaitForSeconds(4f);
        //give results
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);
        //put everything back together
        diceAnim.SetActive(false) ;
        
        if (dice2 + dice1 >= 6)
        {
            //succes
            diceTxt1.text = dice1.ToString();
            diceTxt2.text = dice2.ToString();
            mainTxt.GetComponent<Text>().text = "Success";
            if (dice2 + dice1 == 12)
            {
                mainTxt.GetComponent<Text>().text = "Critical Success";
            }
            //display results 
            acceptSBtn.SetActive(true);            
        }
        else
        {
            //failure
            diceTxt1.text = dice1.ToString();
            diceTxt2.text = dice2.ToString();
            mainTxt.GetComponent<Text>().text = "Fail";
            if (dice2 + dice1 == 2)
            {
                mainTxt.GetComponent<Text>().text = "Critical Fail";
            }
            //displa fail 
            acceptFBtn.SetActive(true) ;         
            
        }
    }

    public void AcceptSucess()
    {
        //wait 
        //mainTxt.SetActive(true);
        acceptSBtn.SetActive(false);
        dicesetUp.SetActive(false);
        vnManag.PlayNextNode(0);
    }

    public void AcceptFailure()
    {
        //wait 
        //mainTxt.SetActive(true);
        acceptFBtn.SetActive(false);
        dicesetUp.SetActive(false);
        vnManag.PlayNextNode(1);
    }


}
