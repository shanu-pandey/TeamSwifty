using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsSpriteCycle : MonoBehaviour {

    public Sprite[] spriteSheet;


    int spriteNumber = 0;
    Sprite currentSprite;
    private float deltaTime = 0;
    private float frameSeconds = 0.0625f;

    // Use this for initialization
    void Start()
    {

        currentSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

        

        //Keep track of the time that has passed
        deltaTime += Time.deltaTime;

        /*Loop to allow for multiple sprite frame 
         jumps in a single update call if needed
         Useful if frameSeconds is very small*/
        while (deltaTime >= frameSeconds)
        {
            deltaTime -= frameSeconds;
            spriteNumber++;
            spriteNumber %= spriteSheet.Length;
        }

        //Animate sprite with selected frame
        GetComponent<Image>().sprite = spriteSheet[spriteNumber];
    }
}
