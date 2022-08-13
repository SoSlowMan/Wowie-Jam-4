using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        creditsScreen.SetActive(false);
        //AudioController.instance.PlayMainMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }
}
