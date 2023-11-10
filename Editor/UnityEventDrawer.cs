#if ODIN_INSPECTOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventDrawer : OdinValueDrawer<UnityEvent>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        var value = ValueEntry.SmartValue;

        EditorGUILayout.Space(2);
        
        if (value.GetPersistentEventCount() == 0)
        {
            // Display button only
            if (GUILayout.Button(label)) UnityEventTools.AddPersistentListener(value);
        }
        else
        {
            // Display default UI
            CallNextDrawer(label);
        }

        ValueEntry.SmartValue = value;
    }
}

public class UnityEventDrawer<T> : OdinValueDrawer<UnityEvent<T>>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        var value = ValueEntry.SmartValue;

        EditorGUILayout.Space(2);
        
        if (value.GetPersistentEventCount() == 0)
        {
            // Display button only
            if (GUILayout.Button(label)) UnityEventTools.AddPersistentListener(value);
        }
        else
        {
            // Display default UI
            CallNextDrawer(label);
        }

        ValueEntry.SmartValue = value;
    }
}
#endif