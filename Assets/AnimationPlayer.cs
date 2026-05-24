using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string parmeterName;

    [SerializeField] private float floatValue;
    [SerializeField] private int intValue;
    [SerializeField] private bool boolValue;

    [SerializeField] private string state;
    [Range(0f,1f)]
    [SerializeField] float time;

    public void SetParameter()
    {
        animator.SetTrigger(parmeterName);
    }

    public void PoseCharacter()
    {
        Debug.Log($"Play state {state}");
        animator.Play(state,0, time);
        animator.Update(0.1f);
    }

}
