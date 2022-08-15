using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingTextScript : MonoBehaviour
{
    [SerializeField] Text textHolder;
    public string charText;
    [SerializeField] float typingSpeed = 0.04f;
    public bool isShown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isShown = true;
            StopAllCoroutines();
            textHolder.text = charText;
        }
    }

    public void StartTyping()
    {
        isShown = false;
        charText = textHolder.text;
        textHolder.text = "";
        StartCoroutine(Show());
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
