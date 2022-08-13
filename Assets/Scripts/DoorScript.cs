using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] float playerRange;
    [SerializeField] GameObject buttonPromt, door;
    public bool isLocked, isOpened;
    [SerializeField] Animator anim1, anim2;
    void Start()
    {
        isLocked = true;
        isOpened = false;
        anim1 = transform.GetChild(0).GetComponentInChildren<Animator>();
        anim2 = transform.GetChild(1).GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            //buttonPromt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isLocked)
                {
                    if (!isOpened)
                        OpenTheDoor();
                    else CloseTheDoor();
                }
                else AudioController.instance.PlayDoorClosedSound();
            }
        }
    }

    void OpenTheDoor()
    {
        anim1.Play("openDoor");
        anim2.Play("openDoor2");
        AudioController.instance.PlayDoorOpenSound();
        isOpened = true;
    }

    void CloseTheDoor()
    {
        anim1.Play("closeDoor");
        anim2.Play("closeDoor2");
        AudioController.instance.PlayDoorCloseSound();
        isOpened = false;
    }
}
