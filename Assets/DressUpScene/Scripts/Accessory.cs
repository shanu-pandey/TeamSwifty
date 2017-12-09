using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accessory : MonoBehaviour {

    public Sprite[] accessorySprite;

    public int selection;
    public string selectionType;

	// Use this for initialization
	void Start () {
        selection = 2;
	}

    void Update()
    {
        //switch (selection)
        //{
        //    case 1:
        //        GetComponent<SpriteRenderer>().color = Color.green;
        //        break;
        //    case 2:
        //        GetComponent<SpriteRenderer>().color = Color.blue;
        //        break;
        //    case 3:
        //        GetComponent<SpriteRenderer>().color = Color.red;
        //        break;
        //    default:
        //        break;
        //}

        //switch (selection)
        //{
        //    case 1:
        //        GetComponent<SpriteRenderer>().sprite = accessorySprite[0];
        //        GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //        break;
        //    case 2:
        //        GetComponent<SpriteRenderer>().sprite = accessorySprite[1];
        //        GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //        break;
        //    case 3:
        //        GetComponent<SpriteRenderer>().sprite = accessorySprite[2];
        //        GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //        break;
        //    default:
        //        break;
        //}

        switch (selection)
        {
            case 1:
                GetComponent<Image>().sprite = accessorySprite[0];
                if (selectionType == "hair")
                    GlobalValues.SetHairType(1);
                else if (selectionType == "dress")
                    GlobalValues.SetDressType(1);
                break;
            case 2:
                GetComponent<Image>().sprite = accessorySprite[1];
                if (selectionType == "hair")
                    GlobalValues.SetHairType(2);
                else if (selectionType == "dress")
                    GlobalValues.SetDressType(2);
                break;
            case 3:
                GetComponent<Image>().sprite = accessorySprite[2];
                if (selectionType == "hair")
                    GlobalValues.SetHairType(3);
                else if (selectionType == "dress")
                    GlobalValues.SetDressType(3);
                break;
            default:
                break;
        }
    }

    public void changeSelection(bool dir)
    {
        if (dir)
        {
            if (selection != 3)
                selection++;
            else
                selection = 1;
        }
        else
        {
            if (selection != 1)
                selection--;
            else
                selection = 3;
        }
    }
}
