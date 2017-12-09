using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameDialogs_fake : MonoBehaviour {
      
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
    private int checkShow = 0;
    private int bad = -1;
    private int characterIndex = 0;
    private int continueDialog = -1;
    private int continueShow = 0;
    private int continueCounter = 0;
    private int show = 0;
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

        if (textFile != null)
        {
            if (GlobalValues.inRelationship)
            {
                currentLine = 55;
                continueDialog = 10;
            }
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
        //StartCoroutine(ShowText(conversations, "no response"));
        //StartCoroutine(ShowFakeText());
        backgroundMusic = GameObject.FindGameObjectsWithTag("BackgroundMusic");

        if (GlobalValues.inRelationship)
        {
            StartCoroutine(ShowText(conversations, "no response"));
            backgroundMusic[0].GetComponent<AudioSource>().Play();
        }
        else
        {
            StartCoroutine(ShowFakeText());
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
	IEnumerator ShowFakeText()
	{
        options.SetActive(false);
        _continue.SetActive(false);
        string fake = "";
        continueShow = show;
        if (show == 0)
        {
            fake = "Deep: Wow, you look simply divine. A beautiful woman for an elegant afternoon on the beach. Let's have the magic of this moment fill our souls with serenity. ";
            for (int j = 0; j < fake.Length; j++)
            {
                dialog.text = fake.Substring(0, j);
                yield return new WaitForSeconds(delay);
            }
            checkShow = 10;
            options.SetActive(true);
            Button[] obj = options.GetComponentsInChildren<Button>(true);
            obj[0].GetComponentInChildren<Text>().text = "Life is... ";
            obj[1].GetComponentInChildren<Text>().text = "Slow Down ";
            obj[2].GetComponentInChildren<Text>().text = "Serenity ";
        }
        else if (show == 1)
        {
            if (continueCounter == 0)
            {
                ChangeCharacter("satart");
                fake = "Taylor: Each moment is a piece of life. We just need to find the right pieces to put the puzzle together. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                foreach (GameObject effect in soundEffects)
                {
                    if (effect.name.Contains("ife"))
                    {
                        effect.GetComponent<AudioSource>().Play();
                    }
                }
                ChangeCharacter("start");
                fake = "Deep: That defines inspirational. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = "Deep: If only society had the aspiration for knowledge that we have. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                continueCounter = 0;
                checkShow = 20;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Mainstream media... ";
                obj[1].GetComponentInChildren<Text>().text = "People Skills... ";
                obj[2].GetComponentInChildren<Text>().text = "No one cares... ";
            }
        }
        else if (show == 2)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Let's just have a good time and see if this works out. No need for the big expectations. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Oh sorry, my heart sometimes moves as fast as my intellect. I need to tell my heart to take a step back sometimes. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = "Deep: If only society had the same aspiration for knowledge that I have. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                continueCounter = 0;
                checkShow = 20;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Mainstream media... ";
                obj[1].GetComponentInChildren<Text>().text = "People Skills... ";
                obj[2].GetComponentInChildren<Text>().text = "No one cares... ";
            }
        }
        else if (show == 3)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: What does serenity mean? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Have you ever read a novel before? Or even a poem for that matter? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: If only society had the aspiration for knowledge that we have. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 20;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Mainstream media... ";
                obj[1].GetComponentInChildren<Text>().text = "People Skills... ";
                obj[2].GetComponentInChildren<Text>().text = "No one cares... ";
            }
        }
        else if (show == 4)
        {
            if (continueCounter == 0)
            {
                ChangeCharacter("asdA");
                fake = "Taylor: Mainstream media corrupts everyone's minds. No one reads real novels anymore. God is dead. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                ChangeCharacter("start");
                foreach (GameObject effect in soundEffects)
                {
                    if (effect.name.Contains("stream"))
                    {
                        effect.GetComponent<AudioSource>().Play();
                    }
                }
                fake = "Deep: Texting and the modern notion of what is regarded as literature has corrupted our souls. But the truth you speak inspires those who listen. And...I'm listening. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = "Deep: So, what are you all about? What is your meaning? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 30;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "I'm unexplainable ";
                obj[1].GetComponentInChildren<Text>().text = "You first ;) ";
                obj[2].GetComponentInChildren<Text>().text = "Texting ";
            }
        }
        else if (show == 5)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Knowledge is important but it isn't connecting with those around you what really counts? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Perhaps, but people are temporary. The knowledge you uncover can last forever. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = "Deep: Anyway, what are you all about? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 30;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "I'm unexplainable ";
                obj[1].GetComponentInChildren<Text>().text = "You first ;) ";
                obj[2].GetComponentInChildren<Text>().text = "Texting ";
            }
        }
        else if (show == 6)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Oh J Christ, can you calm down please? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: I will not calm down until the entirity of humanity is enlightened, madam. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: Who are you suppossed to be, again? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 30;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "I'm unexplainable ";
                obj[1].GetComponentInChildren<Text>().text = "You first ;) ";
                obj[2].GetComponentInChildren<Text>().text = "Texting ";
            }
        }
        else if (show == 7)
        {
            if (continueCounter == 0)
            {
                ChangeCharacter("asdaD");
                fake = "Taylor: It's not something you will find in a dictionary. It's something you discover through experience ;) ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                ChangeCharacter("start");
                foreach (GameObject effect in soundEffects)
                {
                    if (effect.name.Contains("nexpl"))
                    {
                        effect.GetComponent<AudioSource>().Play();
                    }
                }
                fake = "Deep: MMMMMMMM ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: Shall we indulge in some wine, perhaps? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 40;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "My pallet's refined ";
                obj[1].GetComponentInChildren<Text>().text = "Whatever.. ";
                obj[2].GetComponentInChildren<Text>().text = "Like totally! ";
            }
        }
        else if (show == 8)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: You go first ;) ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Oh, uh, I'm constantly trying to discover myself. Anyway... ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: Shall we indulge in some wine, perhaps? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 40;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "My pallet's refined ";
                obj[1].GetComponentInChildren<Text>().text = "Whatever.. ";
                obj[2].GetComponentInChildren<Text>().text = "Like totally! ";
            }
        }
        else if (show == 9)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Oh my god, I love to text! It's like what I'm all about. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Like THAT expands your mind. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: UHHH, texting has destroyed the purity of language forever. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 50;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Irony... ";
                obj[1].GetComponentInChildren<Text>().text = "Maybe for you ";
                obj[2].GetComponentInChildren<Text>().text = "Words..SMH ";
            }
        }
        else if (show == 10)
        {
            if (continueCounter == 0)
            {
                ChangeCharacter("staart");
                fake = "Taylor: I like my wine like I like my men...aged and refined. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                foreach (GameObject effect in soundEffects)
                {
                    if (effect.name.Contains("pall"))
                    {
                        effect.GetComponent<AudioSource>().Play();
                    }
                }
                ChangeCharacter("start");
                fake = "Deep: You have a mature pallet I see... If you listen to the sea closely you will hear it calling our names. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " Deep: Shall we take this wine and this conversation to the waves? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 60;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Sure but... ";
                obj[1].GetComponentInChildren<Text>().text = "Certainly ";
                obj[2].GetComponentInChildren<Text>().text = "Forget the waves... ";
            }
        }
        else if (show == 11)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Whatever gets me drunk... ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Its not about getting drunk...Its about when the hints of oak and herbs splash against your taste buds... ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " ..And the aroma of the grapes bring you back to vintage times when people's thoughts had meaning. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 70;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Enlightened ";
                obj[1].GetComponentInChildren<Text>().text = "Pretentious ";
                obj[2].GetComponentInChildren<Text>().text = "OMG.. ";
            }
        }
        else if (show == 12)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Like totally! I drank so many boxes of wine in my sororiety. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: Its not about getting drunk...Its about when the hints of oak and herbs splash against your taste buds... ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = " ..And the aroma of the grapes bring you back to vintage times when people's thoughts had meaning. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 70;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Enlightened ";
                obj[1].GetComponentInChildren<Text>().text = "Pretentious ";
                obj[2].GetComponentInChildren<Text>().text = "OMG.. ";
            }
        }
        else if (show == 21)
        {
            if (continueCounter == 0)
            {
                ChangeCharacter("starzst");
                fake = "Taylor: Oh, I never thought about wine in such an inspired way. I believe I am starting to become enlightened. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                ChangeCharacter("start");
                fake = "Deep:  Shall we take this wine and this conversation to the waves? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 60;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "Sure but... ";
                obj[1].GetComponentInChildren<Text>().text = "Certainly ";
                obj[2].GetComponentInChildren<Text>().text = "Forget the waves... ";
            }
        }
        else if (show == 13)
        {
            if (continueCounter == 0)
            {
                fake = "Taylor: Relax silly, I was just being ironic... ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else if (continueCounter == 1)
            {
                fake = "Deep: MMMMMM, I misunderstood the deeper meaning of your words. ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                _continue.SetActive(true);
            }
            else
            {
                fake = "Deep: Shall we indulge in some wine, perhaps? ";
                for (int j = 0; j < fake.Length; j++)
                {
                    dialog.text = fake.Substring(0, j);
                    yield return new WaitForSeconds(delay);
                }
                checkShow = 40;
                options.SetActive(true);
                Button[] obj = options.GetComponentsInChildren<Button>(true);
                obj[0].GetComponentInChildren<Text>().text = "My pallet's refined ";
                obj[1].GetComponentInChildren<Text>().text = "Whatever.. ";
                obj[2].GetComponentInChildren<Text>().text = "Like totally! ";
            }
        }
        else
        {
            if (show == 14)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Maybe for you. Maybe the rest of us are just evolving with the world. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else if (continueCounter == 1)
                {
                    fake = "Deep: I see how you have evolved. And I'm glad I'm not part of it. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(false);
                }
            }
            else if (show == 15)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Words are so yesteryear, emojis are what's up today. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else if (continueCounter == 1)
                {
                    fake = "Deep: Real emotions are felt if you look beyond the facade of the modern telephone, which some among us are just not capable of. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(false);
                }
            }
            else if (show == 16)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Oh, I never thought about wine in such a pretentious way before. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else if (continueCounter == 1)
                {
                    fake = "Deep: Clearly I overestimated you're intelect. I think I would rather spend the rest of this evening with my wine bottle than with a simpleton. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(false);
                }
            }
            else if (show == 17)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Oh M God, you're like, older than a typewriter. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else if (continueCounter == 1)
                {
                    fake = "Deep: Clearly I overestimated you're intelect. I think I would rather spend the rest of this evening with my wine bottle than with a simpleton. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(false);
                }
            }
            else if (show == 18)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: I didn't bring a bathing suit ;) ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(true);
                }
            }
            else if (show == 19)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Certainly. We shall have the ocean bring us together as we drown in each other's thoughts. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(true);
                }
            }
            else if (show == 20)
            {
                if (continueCounter == 0)
                {
                    fake = "Taylor: Forget the waves, I want to explore the palace of your endless knowledge until the sun rises. ";
                    for (int j = 0; j < fake.Length; j++)
                    {
                        dialog.text = fake.Substring(0, j);
                        yield return new WaitForSeconds(delay);
                    }
                    _continue.SetActive(true);
                }
                else
                {
                    ShowFakeResult(true);
                }
            }
        }
    }

    IEnumerator ShowText(string[] textLines, string i_response)
    {        
        options.SetActive(false);
        _continue.SetActive(false);
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
                char[] c = textLines[i].ToCharArray(j, 1);
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
                GetChoices(textLines[currentLine+1], textLines[currentLine+3], textLines[currentLine+5]);
                currentLine ++;
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

    public void ShowFakeResult(bool isSuccess)
    {

        options.SetActive(false);

        resultPrompt.SetActive(true);
        if (isSuccess)
            heartsAnim.GetComponent<Image>().enabled = true;

        if (isSuccess)
        {
            Text[] _text = resultPrompt.GetComponentsInChildren<Text>();// = "Bang Bang!!";
            _text[0].text = "You got a Boyfriend!!";
            GlobalValues.fame = 500;
            _text[1].text = "Fame: +" + GlobalValues.fame.ToString();
            ChangeCharacter("end");
            GlobalValues.inRelationship = true;
            
            foreach (GameObject effect in soundEffects)
            {
                if (effect.name.Contains("success"))
                {
                    effect.GetComponent<AudioSource>().Play();
                }
            }
        }
        else
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

        dialog.text = "";


        //EndScene();
    }

    public void Dialog1_Option1()
    {
        if (GlobalValues.inRelationship)
        {
            GlobalValues.response++;
            characterIndex++;
            currentLine++;
            ChangeCharacter("not");
            StartCoroutine(ShowText(conversations, "A"));
        }
        else
        {
            continueCounter = 0;
            if (checkShow == 10)
            {
                show = 1;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 20)
            {
                show = 4;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 30)
            {
                show = 7;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 40)
            {
                show = 10;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 50)
            {
                show = 13;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 60)
            {
                show = 18;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 70)
            {
                show = 21;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 80)
            {
                show = 19;
                StartCoroutine(ShowFakeText());
            }
        }
    }
    public void Dialog1_Option2()
    {
        if (GlobalValues.inRelationship)
        {
            currentLine += 3;
            StartCoroutine(ShowText(conversations, "B"));
            ChangeCharacter("not");
        }
        else
        {
            continueCounter = 0;
            if (checkShow == 10)
            {
                show = 2;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 20)
            {
                show = 5;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 30)
            {
                show = 8;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 40)
            {
                show = 11;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 50)
            {
                show = 14;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 60)
            {
                show = 19;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 70)
            {
                show = 16;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 80)
            {
                show = 19;
                StartCoroutine(ShowFakeText());
            }
        }
    }
    public void Dialog1_Option3()
    {
        if (GlobalValues.inRelationship)
        {
            currentLine += 5;
            characterIndex--;
            StartCoroutine(ShowText(conversations, "C"));
            ChangeCharacter("not");
        }
        else
        {
            continueCounter = 0;
            if (checkShow == 10)
            {
                show = 3;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 20)
            {
                show = 6;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 30)
            {
                show = 9;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 40)
            {
                show = 12;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 50)
            {
                show = 15;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 60)
            {
                show = 20;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 70)
            {
                show = 17;
                StartCoroutine(ShowFakeText());
            }
            else if (checkShow == 80)
            {
                show = 19;
                StartCoroutine(ShowFakeText());
            }
        }
    }
    public void ContinueDialog()
    {
        if (continueDialog != -1)
        {
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
        else
        {
            Debug.Log(show);
            print(show);
            continueCounter++;
            if (continueCounter > 2)
                continueCounter = 0;
            StartCoroutine(ShowFakeText());
        }
    }

    void ChangeCharacter(string moment)
    {
        if (GlobalValues.inRelationship || bad == 0)
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