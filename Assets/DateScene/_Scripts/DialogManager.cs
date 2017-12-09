using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogs;
    public Text dialog;

    public TextAsset textFile;
    public string[] textLines;

    public float delay = 0.01f;
    public int currentLine = 0;
    public int endLine = 5;

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //dialog.text = textLines[currentLine]+ '\n' + "new line";
        StartWriting();
    }

    void StartWriting()
    {
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        //Debug.Log(textLines.Length);
        currentLine = 0;
        foreach (string line in textLines)
        {
            while (currentLine < endLine)
            {
                for (int i = 0; i<textLines[currentLine].Length; i++)
                {
                    dialog.text = textLines[currentLine].Substring(0, i);
                    yield return new WaitForSeconds(delay);
                }
                currentLine++;
                Debug.Log(currentLine);
            }    
        }
        
    }
}

