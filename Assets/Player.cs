using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // int - liczba ca³kowita (1, 214324, -32434)
    // float - liczba z przecinkiem 213.4545f, 23.0f
    // string - tekst "tekst" 
    // bool - zmienna logiczna true/false

    [SerializeField] private float speed = 2;
    [SerializeField] private float jumpForce = 10;
    public int health = 5;
    [SerializeField]
    private bool isAlive;
    //ctrl + r + r - replace wszêdzie
    [SerializeField] private bool isOnTheRight;

    private float timer = 1;
    private Vector2 moveInput;
    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float someFloat = 2;
        someFloat += health;
        string text1 = "tekst 1";
        string text2 = "tekst 2";
        Debug.Log(text1 + health);

        isAlive = !isAlive;

    }

    // Update is called once per frame
    void Update()
    {
        //health -= 1 * Time.deltaTime;
        isAlive = health > 0;
        isOnTheRight = transform.position.x > 5;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            health--;
            timer = 1;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            print("Space pressed");
        }

        //if (isAlive)
        //{
        //    print("is alive");
        //}
        //if (Keyboard.current.dKey.isPressed)
        //{
        //    transform.Translate(speed * Time.deltaTime, 0, 0);
        //}
        //if (Keyboard.current.aKey.isPressed)
        //{
        //    transform.Translate(-speed * Time.deltaTime, 0, 0);
        //}
        Vector2 moveVector = moveInput * speed * Time.deltaTime;

        //transform.position += new Vector3(moveVector.x, 0, moveVector.y);

    }

    private void FixedUpdate()
    {
        Vector2 moveVector = moveInput * speed;
        rb.AddForce(new Vector3(moveVector.x, 0, moveVector.y));
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        print("Move input pressed " + moveInput);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            print("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void DoSomething()
    {

    }
}


