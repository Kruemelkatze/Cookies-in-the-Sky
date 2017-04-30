using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("FINAL");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToHelp()
    {
        SceneManager.LoadScene("Help");
    }

}
