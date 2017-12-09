using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDress : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer[] dress = this.GetComponentsInChildren<SpriteRenderer>();
                
        if (GlobalValues.GetDressType() == 1)
        {        
            dress[0].sortingOrder = 2;
            dress[1].sortingOrder = -1;
            dress[2].sortingOrder = -1;
        }
        else if (GlobalValues.GetDressType() == 2)
        {         
            dress[0].sortingOrder = -1;
            dress[1].sortingOrder = -1;
            dress[2].sortingOrder = 2;
        }
        else if (GlobalValues.GetDressType() == 3)
        {         
            dress[0].sortingOrder = -1;
            dress[1].sortingOrder = 2;
            dress[2].sortingOrder = -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
