using UnityEngine;
using UnityEditor;

public class ChangePrefab : EditorWindow 
{
    public Object OriginObject;
    public Object NewObject;

    [MenuItem("Miso Tools/Exchange Scene Prefabs")]
    static void Init()
    {
        ChangePrefab window = (ChangePrefab)GetWindow(typeof(ChangePrefab));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Select original prefab", EditorStyles.boldLabel);
        OriginObject = EditorGUILayout.ObjectField(OriginObject, typeof(Object), true);
        GUILayout.Space(5);

        GUILayout.Label("Select new prefab", EditorStyles.boldLabel);
        NewObject = EditorGUILayout.ObjectField(NewObject, typeof(Object), true);
        GUILayout.Space(5);
        GUILayout.Space(10);


        EditorGUI.BeginDisabledGroup(OriginObject == null || NewObject == null);

        if (GUILayout.Button("Exchange"))
        {
            GameObject[] gos = FindObjectsOfType<GameObject>();

            for (int i = 0; i < gos.Length; i++)
            {
                if(PrefabUtility.GetCorrespondingObjectFromSource(gos[i]) == OriginObject)
                {
                    Instantiate(NewObject, gos[i].transform.position, gos[i].transform.rotation);
                    DestroyImmediate(gos[i]);
                }
            }
        }

        EditorGUI.EndDisabledGroup();
    }
}
