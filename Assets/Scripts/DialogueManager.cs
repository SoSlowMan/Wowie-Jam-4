using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; set; }
    private Queue<string> sentences;

    [SerializeField] Text textHolder;
    [SerializeField] float typingSpeed = 0.04f;
    public bool isShowing;
    public string thisSentence;

    public Animator dialogueAnim;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isShowing)
        {
            ShowWholeMessage();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {
        textHolder.text = "";
        sentences.Clear();
        dialogueAnim.SetBool("IsOpened", true);
        isShowing = true;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        thisSentence = "";
        textHolder.text = "";
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        thisSentence = sentences.Dequeue();
        StartCoroutine(Show(thisSentence));
        isShowing = true;
    }

    void EndDialogue()
    {
        dialogueAnim.SetBool("IsOpened", false);
    }

    private IEnumerator Show(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            textHolder.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void ShowWholeMessage()
    {
        StopAllCoroutines();
        textHolder.text = thisSentence;
        isShowing = false;
    }
}
