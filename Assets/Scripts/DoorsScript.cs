using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DoorsScript : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    public static DoorsScript instance;

    void Awake()
    {
        instance = this;
    }

    public void OpenDoor(int num)
    {
        doors[num].GetComponent<DoorScript>().isLocked = false;
    }
}