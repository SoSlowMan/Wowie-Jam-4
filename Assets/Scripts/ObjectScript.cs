using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    [SerializeField] float playerRange;
    [SerializeField] public GameObject buttonPromt;
    [SerializeField] public Dialogue[] dialogue;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            buttonPromt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (name)
                {
                    case ("Object1"):
                        PlayerController.instance.hasObj1 = true;
                        DialogueManager.instance.StartDialogue(dialogue[0]);
                        DoorsScript.instance.OpenDoor(0);
                        Destroy(gameObject);
                        break;
                    case ("AI"):
                        //QuestScript.instance.objectBools[1] = true;
                        break;
                }
            }
        }
        else buttonPromt.SetActive(false);
    }
}
