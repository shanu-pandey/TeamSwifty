using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryDisplay : MonoBehaviour {

    public Accessory thisAccessory;
    public Sprite[] accessorySprite;
    public string type;

    private Vector3 scale;

    // Use this for initialization
    void Start () {

        scale = new Vector3(0.6f, 0.6f, 0);
        GetComponent<SpriteRenderer>().transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<SpriteRenderer>().sprite = accessorySprite[thisAccessory.selection - 1];
        if (type == "Dress")
            GlobalValues.SetDressType(thisAccessory.selection);

        if (type == "Hair")
            GlobalValues.SetHairType(thisAccessory.selection);
    }
}
