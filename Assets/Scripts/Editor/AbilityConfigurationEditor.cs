using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbilityConfiguration))]
public class AbilityConfigurationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AbilityConfiguration config = (AbilityConfiguration)target;

        // Draw the default inspector
        DrawDefaultInspector();

        // Add a button to set default values
        if (GUILayout.Button("Set Default Position Variables"))
        {
            // Initialize position variables with default names and values
            SerializedProperty posVarsArray = serializedObject.FindProperty("positionVariablesArray");
            if (posVarsArray.arraySize == 0)
                posVarsArray.arraySize = 4;

            string[] posNames = new string[] { "Duration", "Speed", "Width/Radius", "Frequency" };
            float[] posValues = new float[] { 2f, 10f, 0.5f, 10f };

            for (int i = 0; i < 4; i++)
            {
                SerializedProperty element = posVarsArray.GetArrayElementAtIndex(i);
                SerializedProperty name = element.FindPropertyRelative("name");
                SerializedProperty value = element.FindPropertyRelative("value");
                
                name.stringValue = posNames[i];
                value.floatValue = posValues[i];
            }
            
            serializedObject.ApplyModifiedProperties();
        }

        if (GUILayout.Button("Set Default Damage Variables"))
        {
            // Initialize damage variables with default names and values
            SerializedProperty dmgVarsArray = serializedObject.FindProperty("damageVariablesArray");
            if (dmgVarsArray.arraySize == 0)
                dmgVarsArray.arraySize = 4;

            string[] dmgNames = new string[] { "Initial", "Speed", "Multiplier", "Power" };
            float[] dmgValues = new float[] { 0f, 10f, 1f, 0f };

            for (int i = 0; i < 4; i++)
            {
                SerializedProperty element = dmgVarsArray.GetArrayElementAtIndex(i);
                SerializedProperty name = element.FindPropertyRelative("name");
                SerializedProperty value = element.FindPropertyRelative("value");
                
                name.stringValue = dmgNames[i];
                value.floatValue = dmgValues[i];
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
