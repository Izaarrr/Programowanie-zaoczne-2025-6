using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private float moveSpeed = 1;
    private int currentMoveSpotIndex;
    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {

            int targeSpotIndex = currentMoveSpotIndex;
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                targeSpotIndex = Mathf.Max(currentMoveSpotIndex - 1, 0);
            }
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                targeSpotIndex = Mathf.Min(currentMoveSpotIndex + 1, moveSpots.Length - 1);
            }

            if (targeSpotIndex != currentMoveSpotIndex)
            {
                currentMoveSpotIndex = targeSpotIndex;
                StartCoroutine(MoveToTarget());
            }
        }
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 targetPosition = moveSpots[currentMoveSpotIndex].position;
        while (Vector3.Distance(targetPosition, transform.position) > 0.001)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}
