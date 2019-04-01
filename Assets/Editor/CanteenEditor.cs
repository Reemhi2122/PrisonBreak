using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Canteen))]
public class CanteenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Get all seats"))
        {
            SetProperties();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void SetProperties()
    {
        GameObject CanteenObject = Selection.activeGameObject;
        Canteen canteenObj = CanteenObject.GetComponent<Canteen>();

        canteenObj.canteenChairs = canteenObj.GetComponentsInChildren<CanteenChair>().ToList();
    }
}
