using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameDialogs_new : MonoBehaviour {
      
    public GameObject dialogs;
    public Text dialog;
    public TextAsset textFile;    
    public string[] fileLines;
    public string[] conversations;
    public float delay = 0.01f;
    public int currentLine = 0;
    public int endLine = 5;

    //HeartsAnimationSpriteSheet
    public Image heartsAnim;
	private int optionSelected = 0;
	private int responseSelected = 0;
    private int characterIndex = 0;
    private string[] buttonOption1 = {"Life is..", "Mainstream Media..", "I am unexplainable", "My palate is refined", "Sure, but.."};
    private string[] buttonOption2 = {"Slow down", "No one cares", "You first ;)", "Whatever..", "It's cold!"};
    private string[] buttonOption3 = {"Serenity?", "I guess...", "Texting", "Like totally!", "You wish"};
    public Text lineText;
    GameObject resultPrompt;
    GameObject options;
    GameObject[] johnny;
    private int  response;
    private GameObject _continue;
    AudioSource a;
    GameObject[] soundEffects;
    GameObject[] backgroundMusic;
    string playSound = "";
    // Use this for initialization
    void Start()
    {
        //disable hearts anim before scene starts
        heartsAnim.GetComponent<Image>().enabled = false;
       // GlobalValues.inRelationship = true;
        if (textFile != null)
        {
            if (GlobalValues.inRelationship)
                currentLine = 55;                
            else
                currentLine = 0;

            conversations = textFile.text.Split('\n');
        }
      
        _continue = GameObject.FindGameObjectWithTag("continueDialog");
        options = GameObject.FindGameObjectWithTag("Options");
        resultPrompt = GameObject.FindGameObjectWithTag("ResultPopup");
        johnny = GameObject.FindGameObjectsWithTag("Johnny");


        soundEffects = GameObject.FindGameObjectsWithTag("Effects");
  
        resultPrompt.SetActive(false);
        ChangeCharacter("start");
        response = GlobalValues.likability;
        StartCoroutine(ShowText(conversations, "no response"));
        backgroundMusic = GameObject.FindGameObjectsWithTag("BackgroundMusic");

        if (GlobalValues.inRelationship)
        {
            backgroundMusic[0].GetComponent<AudioSource>().Play();
        }
        else
        {
            backgroundMusic[1].GetComponent<AudioSource>().Play();
            foreach (GameObject effect in soundEffects)
            {
                if (effect.name.Contains("Outfit"))
                {
                    effect.GetComponent<AudioSource>().Play();
                }
            }
        }

        foreach (GameObject j in johnny)
            Debug.Log(j.name);
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator ShowText(string[] textLines, string i_response)
    {        
        options.SetActive(false);
        _continue.SetActive(false);

		if (optionSelected == 2)
			currentLine += 4;
		else if (optionSelected == 3)
			currentLine += 6;
		
        for (int i = currentLine; i < textLines.Length; i++)
		{   
            if (textLines[i].Contains("scene_end"))
            {                
                ChangeCharacter("end");
                ShowResult();
                break;
            }
            if (playSound == "P")
            {
                foreach (GameObject effect in soundEffects)
                {
                    if (textLines[i].Contains(effect.name))
                    {
                        effect.GetComponent<AudioSource>().Play();
                    }
                }
                playSound = "";
                i++;
                currentLine++;
            }
            for (int j = 0; j < textLines[i].Length; j++)
            {                
                //char[] c = textLines[i].ToCharArray(j, 1);
                dialog.text = textLines[i].Substring(0, j);
                yield return new WaitForSeconds(delay);
            }              

            if (i_response == "A")
            {
                currentLine += 5;
                playSound = "P";
            }
            else if (i_response == "B")
            {
                currentLine += 3;
                playSound = "P";
            }
            else if (i_response == "C")
            {
                currentLine++;
                playSound = "P";
            }

            currentLine++;
            if (textLines[currentLine].Contains("dialog") && textLines[currentLine].Contains("over"))
            {
				//if (optionSelected == 1)
				//	currentLine += 6;
				//else if (optionSelected == 2)
				//	currentLine += 3;

				if (optionSelected == 2)
					currentLine += 5;
				else if (optionSelected == 3)
					currentLine += 10;
				
                GetChoices(textLines[currentLine+2], textLines[currentLine+3], textLines[currentLine+4]);
                currentLine += 6;
                break;
            }
            else
            {
                _continue.SetActive(true);
                break;
            }
        }
    } 
  
    public void ShowResult()
    {
        
        options.SetActive(false);

        resultPrompt.SetActive(true);
        if (!GlobalValues.inRelationship)
            heartsAnim.GetComponent<Image>().enabled = true;

        if (GlobalValues.response >0 && !GlobalValues.inRelationship)
        {
            Text[] _text = resultPrompt.GetComponentsInChildren<Text>();// = "Bang Bang!!";
            _text[0].text = "You got a Boyfriend!!";
            GlobalValues.fame = 500;
            _text[1].text = "Fame: +" + GlobalValues.fame.ToString();
            GlobalValues.inRelationship = true;
            foreach (GameObject effect in soundEffects)
            {
                if (effect.name.Contains("success"))
                {
                    effect.GetComponent<AudioSource>().Play();
                }
            }
        }
        else if (GlobalValues.response <0 || GlobalValues.inRelationship)
        {
            Text[] _text = resultPrompt.GetComponentsInChildren<Text>();// = "Bang Bang!!";
            _text[0].text = "It wasn't meant to be";
            GlobalValues.fame += 2000;
            _text[1].text = "Fame: +2000";
            GlobalValues.inRelationship = false;
            foreach (GameObject effect in soundEffects)
            {
                if (effect.name.Contains("Breakup"))
                {
                    effect.GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            Text[] _text = resultPrompt.GetComponentsInChildren<Text>();// = "Bang Bang!!";
            _text[0].text = "You Boring piece of shit!!";
            _text[1].text = "Fame: + 1000" + GlobalValues.fame.ToString();
        }
       

        dialog.text = "";
        

        //EndScene();
    }

    public void Dialog1_Option1()
    {
        GlobalValues.response++;
        characterIndex++;
        currentLine++;
        ChangeCharacter("not");
        StartCoroutine(ShowText(conversations, "A"));        
    }
    public void Dialog1_Option2()
    {
        currentLine += 2;
        StartCoroutine(ShowText(conversations, "B"));
        ChangeCharacter("not");
		optionSelected = 2;
    }
    public void Dialog1_Option3()
    {
        currentLine += 3;
        characterIndex--;
        StartCoroutine(ShowText(conversations, "C"));
        ChangeCharacter("not");
		optionSelected = 3;
    }
    public void ContinueDialog()
    {
        //for (int x = 0; x < johnny.Length; x++)
        //{
        //    if (johnny[x].name.Contains("0"))
        //        johnny[x].SetActive(true);
        //    else
        //        johnny[x].SetActive(false);
        //}

        if (GlobalValues.inRelationship)
        {
            //0-normal   1-sad
            johnny[0].SetActive(true);

            johnny[1].SetActive(false);
            johnny[2].SetActive(false);
            johnny[3].SetActive(false);

        }
        else
        {
            //2- normal   3-sad
            johnny[2].SetActive(true);

            johnny[0].SetActive(false);
            johnny[1].SetActive(false);
            johnny[3].SetActive(false);
        }
        StartCoroutine(ShowText(conversations, "no response"));
    }

    void ChangeCharacter(string moment)
    { 
        if (GlobalValues.inRelationship)
        {
            //0-normal   1-sad
            if (moment == "end")
            {
                johnny[1].SetActive(true);
                johnny[0].SetActive(false);
            }
            else
            {
                johnny[0].SetActive(true);
                johnny[1].SetActive(false);
            }            
            johnny[2].SetActive(false);
            johnny[3].SetActive(false);
        }
        else
        {
            //2- normal   3-sad
            if (moment == "start")
            {
                johnny[2].SetActive(true);
                johnny[3].SetActive(false);
            }
            else
            {
                johnny[3].SetActive(true);
                johnny[2].SetActive(false);
            }
            
            johnny[1].SetActive(false);
            johnny[0].SetActive(false);
        }
               
        //if (characterIndex >= 4)
        //{
        //    johnny[3].SetActive(true);
        //    for (int x = 0; x < johnny.Length-1; x++)
        //    {
        //        johnny[x].SetActive(false);
        //    }
        //}
        //else
        //{
        //    for (int x = 0; x < johnny.Length; x++)
        //    {
        //        if (johnny[x].name.Contains(characterIndex.ToString()))
        //        {
        //            johnny[x].SetActive(true);
        //        }
        //        else
        //        {
        //            johnny[x].SetActive(false);
        //        }
        //    }
        //}
        //if (characterIndex < 0)
        //    johnny[0].SetActive(true);
    }

    void GetChoices(string optionA, string optionB, string optionC)
    {
        options.SetActive(true);
        Button[] obj = options.GetComponentsInChildren<Button>(true);

        obj[0].GetComponentInChildren<Text>().text = optionA.Substring(2);
        obj[1].GetComponentInChildren<Text>().text = optionB.Substring(2);
        obj[2].GetComponentInChildren<Text>().text = optionC.Substring(2);
    }
}