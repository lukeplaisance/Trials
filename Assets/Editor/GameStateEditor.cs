using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Brett;
using UnityEditor;
using UnityEngine;

namespace Brett.Editor
{


    public class GameStateEditor : EditorWindow
    {
        [MenuItem("Tools/GameStateEditor")]
        private static void Init()
        {
            var w = GetWindow(typeof(GameStateEditor));
            w.Show();
        }

        private void OnEnable()
        {

            gameStates = new List<System.Type>();
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(State)))
                    {
                        gameStates.Add(type);
                    }
                }
            }

            var assets = AssetDatabase.FindAssets("t:GameEvent").Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<GameEvent>(path)).Where(gameevent => gameevent).ToList();
            foreach (var a in assets)
            {
                gameEvents.Add(a.name);
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(EditorStyles.helpBox);
            GUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Game States:", EditorStyles.boldLabel);
            scroll = EditorGUILayout.BeginScrollView(scroll);
            for (int i = 0; i < gameStates.Count; i++)
            {
                EditorGUILayout.LabelField(gameStates[i].Name);
                gameStateStrings.Add(gameStates[i].Name);
            }


            GUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

            GUILayout.BeginVertical();
            scroll2 = EditorGUILayout.BeginScrollView(scroll2);
            EditorGUILayout.LabelField("Game State Name", EditorStyles.boldLabel);
            gameStateName = GUILayout.TextField(gameStateName);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Transition Conditions", EditorStyles.boldLabel);

            EditorGUILayout.LabelField("Number of Transitions:");
            numOfTransitions = EditorGUILayout.IntField(numOfTransitions);

            for (int i = 0; i < gameEvents.Count; i++)
            {
                currentTransitionConditionPopup.Add(0);
            }

            for (int i = 0; i < gameStates.Count; i++)
            {
                transitionStates.Add(0);
            }

            EditorGUIUtility.labelWidth = 1;
            for (int i = 0; i < numOfTransitions; i++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("When");
                currentTransitionConditionPopup[i] = EditorGUILayout.Popup(currentTransitionConditionPopup[i], gameEvents.ToArray());
                EditorGUILayout.LabelField("is raised, transition to");
                transitionStates[i] = EditorGUILayout.Popup(transitionStates[i], gameStateStrings.ToArray());
                EditorGUILayout.EndHorizontal();
            }


            if (GUILayout.Button("Create a New GameState") && gameStateName != "")
            {
                var line = "";
                for (int i = 0; i < numOfTransitions; i++)
                {
                    line += "\t\t\t\tif(" + "conditionScriptable.conditions[i].name == " +
                            "\"" + gameEvents[currentTransitionConditionPopup[i]] + "\"" +
                            " && conditionScriptable.conditions[i].isRaised)\n" +
                            "\t\t\t\t{\n" +
                            "\t\t\t\t\tc.ChangeState(new " + gameStateStrings[transitionStates[i]] + "());\n" +
                            "\t\t\t\t\tconditionScriptable.Toggle(" + "\"" + gameEvents[currentTransitionConditionPopup[i]] + "\"" + ");\n" +
                            "\t\t\t\t}\n\n";
                }

                string path = "Assets/Scripts/Brett/State/" + gameStateName + ".cs";
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine("using UnityEngine;\n" +
                                 "\n" +
                                 "namespace Assets.Scripts.Brett\n" +
                                 "{\n" +
                                 "\t[System.Serializable]\n" +
                                 "\tpublic class " + gameStateName + " : State\n" +
                                 "\t{\n" +
                                 "\t\tpublic override void OnEnter()\n" +
                                 "\t\t{\n\t\t}\n\n" +
                                 "\t\tpublic override void OnExit()\n" +
                                 "\t\t{\n\t\t}\n\n" +
                                 "\t\tpublic override void Update(Context c, ConditionScriptable conditionScriptable)\n" +
                                 "\t\t{\n" +
                                 "\t\t\tfor (int i = 0; i < conditionScriptable.conditions.Count; i++)\n\n" +
                                 "\t\t\t{\n" +
                                 line +
                                 "\t\t\t}\n" +
                                 "\t\t}\n" +
                                 "\t}\n}");
                writer.Close();
                AssetDatabase.Refresh();
                Repaint();

            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            if (GUI.changed)
            {
                Repaint();
            }
        }


        private List<System.Type> gameStates = new List<System.Type>();
        private List<string> gameEvents = new List<string>();

        private Vector2 scroll;
        private Vector2 scroll2;

        private int numOfTransitions;

        private List<int> currentTransitionConditionPopup = new List<int>();
        private List<int> transitionStates = new List<int>();

        private List<string> gameStateStrings = new List<string>();


        private string gameStateName;

    }
}