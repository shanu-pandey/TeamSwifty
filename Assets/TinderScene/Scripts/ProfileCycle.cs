using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileCycle : MonoBehaviour {

    public Sprite[] profilePictures;

    public Image imageReference;
    public Text textBoxReference;
    public Text profileNameReference;
    public Text ReqFameReference;

    public int profile;

    private string profileText_1;
    private string profileText_2;
    private string profileText_3;

    private string[] profileName;
    private string[] requiredFame;

    // Use this for initialization
    void Start () {

        profileName = new string[3];
        requiredFame = new string[3];

        requiredFame[0] = "0";
        profileName[0] = "Johnny Deep, 45";
        profileText_1 = "Destiny is like an ocean...\nBut you have to take the right river to get there...\n\nNeed someone of a certain...sophistication... " +
                               "\n\nLet's light the fireplace with ripped out Twilight pages and put it out with fine wine.";

        requiredFame[1] = "1000";
        profileName[1] = "Dwayne's Rock Johnson, 38";
        profileText_2 = "Sup? Call me Rock \n\nBody = a holy temple \n\nWent to the prom with three dates \n\nFuture president of America" +
                            "\n\nHeart of a lion; human hearts can't handle my workout routine";

        imageReference.GetComponent<Image>().sprite = profilePictures[0];
        textBoxReference.GetComponent<Text>().text = profileText_1;
        profileNameReference.GetComponent<Text>().text = profileName[0];

        profile = 1;
	}

    public void nextProfile()
    {
        if (profile != 3)
        {
            profile++;
            updateProfile(profile);
        }
        else
        {
            profile = 1;
            updateProfile(profile);
        }
    }

    public void previousProfile()
    {
        if (profile != 1)
        {
            profile--;
            updateProfile(profile);
        }
        else
        {
            profile = 3;
            updateProfile(profile);
        }
    }

    void updateProfile(int profileNum)
    {

        switch (profileNum)
        {
            case 1:
                imageReference.GetComponent<Image>().sprite = profilePictures[0];
                textBoxReference.GetComponent<Text>().text = profileText_1;
                profileNameReference.GetComponent<Text>().text = profileName[0];
                ReqFameReference.GetComponent<Text>().text = "0";
                break;

            case 2:
                imageReference.GetComponent<Image>().sprite = profilePictures[1];
                textBoxReference.GetComponent<Text>().text = profileText_2;
                profileNameReference.GetComponent<Text>().text = profileName[1];
                ReqFameReference.GetComponent<Text>().text = "1000";
                break;

            case 3:
                imageReference.GetComponent<Image>().sprite = profilePictures[2];
                textBoxReference.GetComponent<Text>().text = "???";
                profileNameReference.GetComponent<Text>().text = "???, ???";
                ReqFameReference.GetComponent<Text>().text = "???";
                break;

            default:
                break;
        }   
    }
}
