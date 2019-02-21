using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zach;

[CreateAssetMenu]
public class NoteBook : ScriptableObject
{
    public List<NoteScriptable> Notes;


    [MenuItem("GameObject/Create Material")]
    static void CreateMaterial()
    {
        // Create a simple material asset

        Material material = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(material, "Assets/MyMaterial.mat");

        // Add an animation clip to it
        AnimationClip animationClip = new AnimationClip();
        animationClip.name = "My Clip";
        AssetDatabase.AddObjectToAsset(animationClip, material);

        // Reimport the asset after adding an object.
        // Otherwise the change only shows up when saving the project
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(animationClip));

        // Print the path of the created asset
        Debug.Log(AssetDatabase.GetAssetPath(material));
    }
}

[CustomEditor(typeof(NoteBook))]
public class NoteBookEditor : Editor
{
    private NoteBook myTarget;


    private void OnEnable()
    {
        myTarget = target as NoteBook;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Merge"))
        {
            var myassetpath = "Assets/Resources/Notes/NoteBookHolder.asset";
            var notebook = CreateInstance("NoteBook");
            AssetDatabase.CreateAsset(notebook, myassetpath);
            AssetDatabase.ImportAsset(myassetpath);

            var myobject = AssetDatabase.LoadAssetAtPath<NoteBook>(myassetpath);
            foreach (var note in myTarget.Notes)
            {
                AssetDatabase.AddObjectToAsset(note, myobject);
            }
        }
    }
}