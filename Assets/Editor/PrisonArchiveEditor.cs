using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrisonArchive))]
public class PrisonArchiveEditor : Editor
{

    SerializedProperty PrisonList;

    private void OnEnable() {
        PrisonList = serializedObject.FindProperty("Prisons");
    }

    public override void OnInspectorGUI(){
        EditorGUILayout.PropertyField(PrisonList, new GUIContent("PrisonList"), true);
        if(GUILayout.Button("PutinPrison")){
            FindPrisons();
        }

        if(GUILayout.Button("SetAllPrisonProperties")){
            GameObject gameObject = Selection.activeGameObject;
            gameObject.GetComponent<PrisonArchive>().AddAllPrisonProperties();
        }

        serializedObject.ApplyModifiedProperties();   
    }

    void FindPrisons()  
    {
        GameObject gameObject = Selection.activeGameObject;
        Prison[] prison = FindObjectsOfType<Prison>();

        for (int i = 0; i < prison.Length; i++)
        {
            gameObject.GetComponent<PrisonArchive>().Prisons[i] = prison[i];
        }
    }
}
