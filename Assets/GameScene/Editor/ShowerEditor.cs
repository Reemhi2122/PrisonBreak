using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Shower))]
public class ShowerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("GetShowerHeads"))
        {
            SetProperties();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void SetProperties()
    {
        GameObject showerObject = Selection.activeGameObject;
        Shower ShowerRoom = showerObject.GetComponent<Shower>();

        ShowerRoom.showerheads = showerObject.GetComponentsInChildren<ShowerHead>();
    }
}
