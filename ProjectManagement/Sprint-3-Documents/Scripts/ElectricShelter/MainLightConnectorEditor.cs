using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainLightConnector))]
public class MainLightConnectorEditor : Editor
{
    private SerializedProperty connectedLightsProp;

    private void OnEnable()
    {
        connectedLightsProp = serializedObject.FindProperty("connectedLights");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        EditorGUILayout.Space(10f);

        if (GUILayout.Button("Add Light"))
        {
            AddLightElement();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void AddLightElement()
    {
        MainLightConnector connector = (MainLightConnector)target;
        Light newLight = null;

        if (connector.ConnectedLights == null)
        {
            connector.ConnectedLights = new List<Light>();
        }

        // Create an undo group to track changes
        Undo.IncrementCurrentGroup();
        int undoGroup = Undo.GetCurrentGroup();

        // Record the changes
        Undo.RegisterCompleteObjectUndo(connector, "Add Light");

        // Add the new light to the list
        connector.ConnectedLights.Add(newLight);

        // End the undo group
        Undo.CollapseUndoOperations(undoGroup);

        // Mark the scene as dirty
        EditorUtility.SetDirty(connector);

        // Reimport the asset database to reflect the changes in the Inspector
        AssetDatabase.Refresh();
    }
}