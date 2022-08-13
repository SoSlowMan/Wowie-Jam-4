using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    private Vector2 moveInput;
    [SerializeField]
    Rigidbody2D theRB;
    private Animator anim;
    string currentLevel;

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //AudioController.instance.PlayLevelMusic();
        //anim = GetComponent<Animator>();
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * moveInput.y;
        Vector3 moveVertical = transform.right * moveInput.x;
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed * Time.deltaTime;
        //anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
    }
}
