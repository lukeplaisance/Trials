using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Luke;
using Matthew;

namespace Lobodestroyo.Editor
{
    public class GameEventEditor : EditorWindow
    {
        [MenuItem("Tools/GameEventEditor")]
        private static void Init()
        {
            var w = GetWindow(typeof(GameEventEditor));
            w.Show();

        }

        private void OnEnable()
        {
            var assets = AssetDatabase.FindAssets("t:GameEvent").Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<GameEvent>(path)).Where(gameevent => gameevent).ToList();
            m_gameEvents = new List<GameEvent>(assets);
            m_contents = m_gameEvents.Select(c => new GUIContent(c.name)).ToArray();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("GameEvents");
            m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos);
            EditorGUILayout.BeginVertical();

            selected = GUILayout.SelectionGrid(selected, m_contents, 4, EditorStyles.miniButton);

            DrawEventListeners(m_gameEvents[selected], selected);
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

            if(GUI.changed)
                Repaint();
        }

        private void DrawEventListeners(GameEvent gameEvent, int index)
        {
            var fieldinfo = gameEvent.GetType().GetField("listeners", BindingFlags.NonPublic | BindingFlags.Instance);
            var l = fieldinfo.GetValue(gameEvent);
            var listeners = l as List<IListener>;

            GUILayout.BeginVertical(EditorStyles.helpBox);
            if(listeners.Count <= 0)
            {
                EditorGUILayout.LabelField(gameEvent.name);
                EditorGUILayout.LabelField("Listeners: 0");
            }
            else
            {
                var width = EditorStyles.miniButton.CalcSize(new GUIContent("Raise"));
                EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
                EditorGUILayout.LabelField(gameEvent.name);
                if(GUILayout.Button("Raise", EditorStyles.toolbarButton, GUILayout.Width(width.x + 1)))
                    gameEvent.Raise();
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel++;
                foreach (var listener in listeners)//show the listeners of this event in window
                {
                    var target = listener as MonoBehaviour;
                    
                    if(target != null)
                    {
                        EditorGUILayout.ObjectField("Listener", target.gameObject, typeof(GameObject), true,
                            GUILayout.MaxWidth(500 - EditorGUI.indentLevel));
                    }
                    else
                    {
                        EditorGUILayout.LabelField(listener.ToString());
                    }
                }

                EditorGUI.indentLevel--;
            }

            GUILayout.EndVertical();
        }

        private GUIContent[] m_contents;


        private List<GameEvent> m_gameEvents = new List<GameEvent>();

        private Vector2 m_scrollPos;


        private int selected;
    }
}