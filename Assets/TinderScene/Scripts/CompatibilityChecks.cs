using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompatibilityChecks : MonoBehaviour {
    
    public Camera mainCamera;
    public CanvasGroup FamePopUp;
    public CanvasGroup RelationshipPopUp;

    private ProfileCycle thisProfile;
    private Fade screenFade;

    private void Start()
    {
        thisProfile = GetComponent<ProfileCycle>();
        screenFade = mainCamera.GetComponent<Fade>();
    }

    public void CheckFameLevel()
    {
        if(thisProfile.profile == 1)
        {
            //Debug.Log("LETS GO!");
            screenFade.EndScene();
        }
        else if (thisProfile.profile == 2)
        {
            if (GlobalValues.IsInRelationship())
            {
                RelationshipPopUp.alpha = 1;
                RelationshipPopUp.interactable = true;
                RelationshipPopUp.blocksRaycasts = true;
                //Debug.Log("You are already in a relationship!");
            }
            else
            {
                if (GlobalValues.fame < 100)
                {
                    //Debug.Log("NOT FAMOUS ENOUGH");
                    FamePopUp.alpha = 1;
                    FamePopUp.interactable = true;
                    FamePopUp.blocksRaycasts = true;
                    FamePopUp.GetComponentInChildren<Text>().text = "He look tasty don't he? Get more FAME or take him off the market for only .99¢";
                }
                else
                {
                    //Debug.Log("LETS GO!");
                    screenFade.EndScene();
                }
            } 
        }
        else
        {
            //Debug.Log("NOT FAMOUS ENOUGH");
            FamePopUp.alpha = 1;
            FamePopUp.interactable = true;
            FamePopUp.blocksRaycasts = true;
            FamePopUp.GetComponentInChildren<Text>().text = "Wondering who she is? Find out for only .99¢";
        }
    }
}
