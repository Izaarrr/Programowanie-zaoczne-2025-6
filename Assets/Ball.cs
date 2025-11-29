using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] PinManager pinManager;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float launchForce = 10;
    [SerializeField] private float scoreWaitTime = 5f;
    private int throwCount;
    private Rigidbody rb;
    private bool wasLaunched;
    private float horizontalInput;
    Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!wasLaunched)
        {
            transform.position += Vector3.right * horizontalInput * Time.deltaTime * moveSpeed;
        }

    }

    private void OnMoveHorizontal(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }

    private void OnAttack()
    {
        if(!wasLaunched)
        {
            throwCount++;
            wasLaunched = true;
            rb.isKinematic = false;
            rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
            StartCoroutine(WaitForScore());
        }
    }

    private IEnumerator WaitForScore()
    {
        print("Start wait");
        yield return new WaitForSeconds(scoreWaitTime);
        pinManager.CleanupAfterThrow();
        print("Finish wait");
        wasLaunched = false;
        transform.position = startPosition;
        rb.isKinematic = true;

        if (throwCount == 2)
        {
            //TODO: Show score
            yield return new WaitForSeconds(2);
            pinManager.ResetPins();
            throwCount = 0;
        }
    }
}
