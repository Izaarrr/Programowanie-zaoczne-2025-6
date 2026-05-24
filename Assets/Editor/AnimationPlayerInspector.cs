using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.Animations;

[CustomEditor(typeof(AnimationPlayer))]
public class AnimationPlayerInspector : Editor
{
    private int parameterIndex;
    SerializedProperty parameterNameProperty;
    SerializedProperty animatorProperty;
    SerializedProperty floatProperty;
    SerializedProperty intProperty;
    SerializedProperty boolProperty;
    SerializedProperty stateProperty;
    SerializedProperty timeProperty;

    private int animationStateIndex;

    private void OnEnable()
    {
        parameterNameProperty = serializedObject.FindProperty("parmeterName");
        animatorProperty = serializedObject.FindProperty("animator");
        floatProperty = serializedObject.FindProperty("floatValue");
        intProperty = serializedObject.FindProperty("intValue");
        boolProperty = serializedObject.FindProperty("boolValue");
        stateProperty = serializedObject.FindProperty("state");
        timeProperty = serializedObject.FindProperty("time");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(animatorProperty);
        Animator animator = (Animator)animatorProperty.objectReferenceValue;
        string parameterName = parameterNameProperty.stringValue;
        Debug.Log(parameterName);
        Debug.Log("Update editor");


        //AnimationPlayer animationPlayer = (AnimationPlayer)target;
        if (animator == null)
        {
            Debug.LogError("No animator");
            return;
        }

        AnimatorControllerParameter[] parameters = animator.parameters;
        //string[] parameterNames = new string[parameters.Length];
        //for (int i = 0; i < parameterNames.Length; i++)
        //{
        //    parameterNames[i] = parameters[i].name;
        //}

        string[] parameterNames = parameters.Select(parameter => parameter.name).ToArray();
        parameterIndex = parameterNames.ToList().IndexOf(parameterName);
        if (parameterIndex == -1)
        {
            parameterIndex = 0;
        }
        parameterIndex = EditorGUILayout.Popup(parameterIndex, parameterNames);
        AnimatorControllerParameterType parameterType = parameters[parameterIndex].type;
        switch(parameterType)
        {
            case AnimatorControllerParameterType.Float:
                floatProperty.floatValue = EditorGUILayout.FloatField(floatProperty.floatValue);
                break;
            case AnimatorControllerParameterType.Int:
                intProperty.intValue = EditorGUILayout.IntField(intProperty.intValue);
                break;
            case AnimatorControllerParameterType.Bool:
                boolProperty.boolValue = EditorGUILayout.Toggle(boolProperty.boolValue);
                break;
            default:
                break;
        }

        //animationPlayer.parmeterName = parameterNames[parameterIndex];
        parameterNameProperty.stringValue = parameterNames[parameterIndex];
       

        AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;
        if(animatorController == null )
        {
            return;
        }
        string[] states = animatorController.layers[0].stateMachine.states
            .Select(state => state.state.name)
            .ToArray();

        animationStateIndex = EditorGUILayout.Popup(animationStateIndex, states);
        stateProperty.stringValue = states[animationStateIndex];
        EditorGUILayout.PropertyField(timeProperty);
        if (GUILayout.Button( "Apply pose"))
        {
            AnimationPlayer player = serializedObject.targetObject as AnimationPlayer;
            player.PoseCharacter();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
