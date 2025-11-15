using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;
    [SerializeField] float launchForce = 10;
    Rigidbody rb;
    bool wasLaunched;
    float horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
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
        wasLaunched = true;
        rb.isKinematic = false;
        rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
    }
}
