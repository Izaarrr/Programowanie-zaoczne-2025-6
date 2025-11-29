using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public bool IsKnockedDown;
    public float angle;
    [SerializeField] private float knockDownAngle = 10;
    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        angle = Vector3.Angle(Vector3.up, transform.up);
        //IsKnockedDown = angle > knockDownAngle; Inny sposób
        if (angle > knockDownAngle)
        {
            IsKnockedDown = true;
        }
        else
        {
            IsKnockedDown = false;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ResetState()
    {

        gameObject.SetActive(true);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //transform.position = startPosition;
        //transform.rotation = startRotation;
        transform.SetPositionAndRotation(startPosition, startRotation);
    }
}
