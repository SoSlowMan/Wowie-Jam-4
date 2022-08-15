using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    [SerializeField] float playerRange;
    [SerializeField] GameObject buttonPromt;

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
                        QuestScript.instance.objects[0] = true;
                        Destroy(gameObject);
                        break;
                    case ("AI"):
                        QuestScript.instance.objects[1] = true;
                        break;
                }
            }
        }
        else buttonPromt.SetActive(false);
    }
}
