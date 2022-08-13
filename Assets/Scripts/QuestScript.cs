using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] messages;
    public bool[] objects;
    public static QuestScript instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DropAllItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (objects[0])
        {
            Object1();
        }
    }

    public void CloseAllMessages()
    {
        foreach (GameObject message in messages)
        {
            message.SetActive(false);
        }
    }

    void DropAllItems()
    {
        foreach (bool obj in objects)
        {
            obj.Equals(false);
        }
    }

    void Object1()
    {
        doors[0].GetComponent<DoorScript>().isLocked = false;
        messages[0].SetActive(true);
        objects[0] = false;
    }
}
