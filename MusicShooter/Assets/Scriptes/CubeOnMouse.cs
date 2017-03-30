using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CubeOnMouse : MonoBehaviour {

    public enum Cube
    {
        blue,
        yellow,
        green,
    }
    public Cube cube;

    public GameObject panel;

    public GameObject text;
    Vector3 textPos;

    bool fadeEnd = false;

	void Start () 
    {
        textPos = text.transform.position;
	}
	
	void Update () 
    {
		
	}

    void OnMouseOver()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", -1f));
        iTween.RotateTo(gameObject, iTween.Hash("y", 90f,"time", 0.5f,"easeType","linear", "loopType", "loop"));
        iTween.MoveTo(text,iTween.Hash("position",new Vector3(0f,2f,-6.5f)));
    }

    void OnMouseExit()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", -2f));
        iTween.RotateTo(gameObject, iTween.Hash("y", 0f));
        iTween.MoveTo(text, iTween.Hash("position", textPos));
    }
    void OnMouseDown()
    {
        FadeIn();
    }

    void FadeIn()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 1f, "onupdate", "SetValue"));
        Invoke("Button", 2f);
	}
    void SetValue(float alpha)
    {
        panel.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, alpha);
        Debug.Log(alpha);
    }
    void Button()
    {
        switch (cube)
        {
            case Cube.blue:

                break;

            case Cube.green:

                break;

            case Cube.yellow:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
