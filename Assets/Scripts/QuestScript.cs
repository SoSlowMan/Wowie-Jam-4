using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject messageScreen;
    public bool[] objects;
    public static QuestScript instance;
    [SerializeField] string[] texts;
    [SerializeField] int countNow;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        TextFill();
        DropAllItems();
        PlayDialogue(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        StopPlayer();
        
        if (objects[0])
        {
            //Object1();
            
        }

        if (objects[1])
        {
            ObjectAI();
        }

        if (messageScreen.activeSelf == true)
        {
            int i = 0;
            
        }
    }

    public void CloseAllMessages()
    {
        messageScreen.SetActive(false);
        StopAllCoroutines();
        messageScreen.transform.GetChild(0).GetComponent<TypingTextScript>().isShown = false;
        PlayerController.instance.isBusy = false;
    }

    void DropAllItems()
    {
        foreach (bool obj in objects)
        {
            obj.Equals(false);
        }
    }

    void StopPlayer()
    {
        if (messageScreen.activeSelf)
        {
            PlayerController.instance.isBusy = true;
        }
    }

    void Object1()
    {
        messageScreen.transform.GetChild(0).GetComponent<Text>().text = texts[1] + texts[2];
        OpenMessage();
        PlayerController.instance.hasObj1 = true;
        objects[0] = false;
        OpenDoor(0);
    }

    void ObjectAI()
    {
        //PlayDialogue(0);
    }

    void OpenDoor(int num)
    {
        doors[num].GetComponent<DoorScript>().isLocked = false;
    }

    void OpenMessage()
    {
        messageScreen.SetActive(true);
        messageScreen.transform.GetChild(0).GetComponent<TypingTextScript>().StartTyping();
    }

    void ClearTheText()
    {
        messageScreen.transform.GetChild(0).GetComponent<TypingTextScript>().isShown = false;
        messageScreen.transform.GetChild(0).GetComponent<Text>().text = "";
    }

    void PlayDialogue(int num, int count)
    {
        string[] dialogues;
        countNow = count;
        dialogues = new string[count];
        switch (num)
        {
            case (0):
                dialogues[0] = texts[0];
                dialogues[1] = texts[1];
                Play();
                PlayerController.instance.hasObj1 = true;
                objects[0] = false;
                OpenDoor(0);
                break;
        }
        
        void Play()
        {
            int i = 0;
            do
            {
                messageScreen.transform.GetChild(0).GetComponent<Text>().text = dialogues[i];
                OpenMessage();
                i++;
                if (Input.GetKeyDown(KeyCode.E) && messageScreen.transform.GetChild(0).GetComponent<TypingTextScript>().isShown == true)
                {
                    Debug.Log(i);
                    messageScreen.transform.GetChild(0).GetComponent<Text>().text = "";
                    //ClearTheText();
                    if (i == countNow)
                    {
                        //CloseAllMessages();
                    }
                }
            }
            while (i == count);
        }
    }

    void TextFill()
    {
        texts[0] = "You wake up in your room and the only thing you remember is that you walk with WASD and interact with doors and objects using E button. Oh, and also you can close messages by using E button";
        texts[1] = "You find your badge and discover that your name is Fred Tipoque and you are spacecraft engineer 28th class (lowest class in the universe). ";
        texts[2] = "You also find your journal that only consists of praise for your everyday meal: pasta carbonara. The memories of it's wonderful texture, rich flavour and amazing sauce fill your mind. You feel hungry. You need to find more pasta! And fast!\nYou can open the door now!";
        texts[3] = "Oh what joy! At least someone survived the horrific meteorite impact yesterday. Buddy, I can't steer the ship because of the damage, fix me up and we can go home after this terrible tragedy!";
    }
}
