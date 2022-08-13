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
    public bool isBusy;
    private SpriteRenderer sprite;

    public static PlayerController instance;

    private States State //свойство типа States
    {
        get { return (States)anim.GetInteger("State"); } //получаем значение state из аниматора
        set { anim.SetInteger("State", (int)value); } //меняем значение state
    }

    private void Awake()
    {
        instance = this;
        sprite = GetComponentInChildren<SpriteRenderer>();
        //AudioController.instance.PlayLevelMusic();
        anim = GetComponent<Animator>();
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isBusy)
        {
            State = States.idle;
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 moveHorizontal = transform.up * moveInput.y;
            Vector3 moveVertical = transform.right * moveInput.x;
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed * Time.deltaTime;
            if (Input.GetAxis("Vertical") > 0)
            {
                State = States.MoveYUp;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                State = States.MoveYDown;
            }
        }
    }

    private void Run()
    {
        State = States.run; //включение анимации бега

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        sprite.flipX = dir.x < 0.0f;
    }

    public enum States
    {
        idle,
        run,
        MoveYUp,
        MoveYDown
    }
}
