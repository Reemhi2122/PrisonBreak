using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Prison))]
public class CellEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("GetProperties"))
        {
            SetProperties();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void SetProperties(){
        GameObject gameObject = Selection.activeGameObject;
        Prison myPrison = gameObject.GetComponent<Prison>();

        myPrison.door = gameObject.GetComponentInChildren<Door>();
        myPrison.bed = gameObject.transform.GetChild(1).gameObject;
        myPrison.toilet = gameObject.transform.GetChild(2).gameObject;
    }
}
