using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

#if UNITY_EDITOR
[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    SerializedProperty m_QuestInfoProperty;
    SerializedProperty m_QuestStateProperty;

    List<string> m_QuestGoalType;
    SerializedProperty m_QuestGoalListproperty;

    [MenuItem("Assets/Quest", priority=0)]

    public static void CreatQuest()
    {
        var newQuest=CreateInstance<Quest>();
        ProjectWindowUtil.CreateAsset(newQuest, "quest.asset");
    }
    private void OnEnable()
    {
        m_QuestInfoProperty = serializedObject.FindProperty("Information");
        m_QuestStateProperty=serializedObject.FindProperty("Reward");
        m_QuestGoalListproperty = serializedObject.FindProperty("Goals");

        var lookup = typeof(QuestGoal);
        m_QuestGoalType = System.AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly=>assembly.GetTypes())
            .Where(x=>x.IsClass && !x.IsAbstract && x.IsSubclassOf(lookup))
            .Select(type=>type.Name)
            .ToList();
    }

    public override void OnInspectorGUI()
    {
        SerializedProperty child =m_QuestInfoProperty.Copy();
        int depth = child.depth;
        child.NextVisible(true);

        EditorGUILayout.LabelField("Quest info", EditorStyles.boldLabel);


        while(child.depth > depth)
        {
            EditorGUILayout.PropertyField(child, true);
            child.NextVisible(false);
        }


        child =m_QuestStateProperty.Copy();
        depth = child.depth;
        child.NextVisible(true);


        EditorGUILayout.LabelField("Quest reward", EditorStyles.boldLabel);


        while (child.depth > depth)
        {
            EditorGUILayout.PropertyField(child, true);
            child.NextVisible(false);
        }

        int choice = EditorGUILayout.Popup("Add new Quest Goal", -1, m_QuestGoalType.ToArray());
        if(choice!=-1)
        {
            var newInstance= ScriptableObject.CreateInstance(m_QuestGoalType[choice]);

            AssetDatabase.AddObjectToAsset(newInstance, target);

            m_QuestGoalListproperty.InsertArrayElementAtIndex(m_QuestGoalListproperty.arraySize);
            m_QuestGoalListproperty.GetArrayElementAtIndex(m_QuestGoalListproperty.arraySize - 1)
                .objectReferenceValue = newInstance;
        }
        Editor ed = null;
        int toDelet = -1;
        for(int i=0;i<m_QuestGoalListproperty.arraySize;++i)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            var item = m_QuestGoalListproperty.GetArrayElementAtIndex(i);
            SerializedObject obj = new SerializedObject(item.objectReferenceValue);
            Editor.CreateCachedEditor(item.objectReferenceValue, null, ref ed);

            ed.OnInspectorGUI();
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("-", GUILayout.Width(32)))
            {
                toDelet = i;
            }
            EditorGUILayout.EndHorizontal();


        }
        if(toDelet!=-1)
        {
            var item = m_QuestGoalListproperty.GetArrayElementAtIndex(toDelet).objectReferenceValue;
            DestroyImmediate(item, true);

            m_QuestGoalListproperty.DeleteArrayElementAtIndex(toDelet);
            m_QuestGoalListproperty.DeleteArrayElementAtIndex(toDelet);

        }
        serializedObject.ApplyModifiedProperties();
    }

}
#endif
