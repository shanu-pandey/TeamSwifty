using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBreak : MonoBehaviour {

    public CanvasGroup popup;

    bool check = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (GlobalValues.IsInRelationship())
        {
            if (check)
            {
                check = false;
                popup.alpha = 1;
                popup.interactable = true;
                popup.blocksRaycasts = true;
            }
        }
	}
}
