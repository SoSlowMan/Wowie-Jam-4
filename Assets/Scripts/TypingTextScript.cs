using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingTextScript : MonoBehaviour
{
    [SerializeField] Text textHolder;
    string charText;
    [SerializeField] float typingSpeed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        charText = textHolder.text;
        textHolder.text = "";
        StartCoroutine(Show());
    }

    void Update()
    {
        //Show();
    }

    private IEnumerator Show()
    {
        foreach (char letter in charText.ToCharArray())
        {
            textHolder.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
