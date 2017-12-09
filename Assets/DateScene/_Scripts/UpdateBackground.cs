using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBackground : MonoBehaviour {

    public Sprite date;
    public Sprite breakup;

    // Use this for initialization
    void Start () {
        if (GlobalValues.name == "Deep")
        {
            if (GlobalValues.IsInRelationship())
                this.GetComponent<SpriteRenderer>().sprite = breakup;
            else
                this.GetComponent<SpriteRenderer>().sprite = date;
        }
        else if (GlobalValues.name == "Rock")
        {
            if (GlobalValues.IsInRelationship())
                this.GetComponent<SpriteRenderer>().sprite = breakup;
            else
                this.GetComponent<SpriteRenderer>().sprite = date;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
