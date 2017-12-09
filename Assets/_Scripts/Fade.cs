using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;
    public int nextScene;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

	
	void OnGUI ()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	
	
	public float BeginFade (int direction)
    {
        fadeDir = direction;
        return fadeSpeed;		
	}

    void OnLevelLoad ()
    {
        BeginFade(-1);
    }

    IEnumerator FadeEffect()
    {
        Debug.Log("transition here");
        float fadeTime = gameObject.GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextScene);
    }

    public void EndScene()
    {
        StartCoroutine(FadeEffect());
    }
}
