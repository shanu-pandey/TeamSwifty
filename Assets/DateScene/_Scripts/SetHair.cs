using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHair : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer[] hair = this.GetComponentsInChildren<SpriteRenderer>();
              
        if (GlobalValues.GetHairType() == 1)
        {            
            hair[0].sortingOrder = -1;
            hair[1].sortingOrder = -1;
            hair[2].sortingOrder = 3;
        }
        else if (GlobalValues.GetHairType() == 2)
        {         
            hair[0].sortingOrder = 3;
            hair[1].sortingOrder = -1;
            hair[2].sortingOrder = -1;
        }
        else if (GlobalValues.GetHairType() == 3)
        {         
            hair[0].sortingOrder = -1;
            hair[1].sortingOrder = 3;
            hair[2].sortingOrder = -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
