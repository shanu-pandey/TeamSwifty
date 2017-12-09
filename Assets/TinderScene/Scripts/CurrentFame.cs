using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentFame : MonoBehaviour {

    void Start()
    {
        GetComponent<Text>().text = GlobalValues.fame.ToString();
    }

    // Update is called once per frame
    void Update () {

        GetComponent<Text>().text = GlobalValues.fame.ToString();
        Debug.Log(GlobalValues.fame);
	}
}
