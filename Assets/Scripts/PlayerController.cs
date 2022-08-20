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
    public bool hasObj1;
    [SerializeField] Animator dialogueAnim;

    public static PlayerController instance { get; set; }

    private States State //свойство типа States
    {
        get { return (States)anim.GetInteger("State"); } //получаем значение state из аниматора
        set { anim.SetInteger("State", (int)value); } //меняем значение state
    }

    private void Awake()
    {
        instance = this;
        sprite = GetComponent<SpriteRenderer>();
        //AudioController.instance.PlayLevelMusic();
        anim = GetComponent<Animator>();
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
    void Start()
    {
        hasObj1 = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueAnim.GetBool("IsOpened") == true)
        {
            isBusy = true;
            State = States.idle;
        }
        else isBusy = false;

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

            if (Input.GetAxis("Horizontal") != 0)
            {
                State = States.run;
                sprite.flipX = moveVertical.x > 0.0f;
            }
        }
    }

    public enum States
    {
        idle,
        run,
        MoveYUp,
        MoveYDown
    }
}
