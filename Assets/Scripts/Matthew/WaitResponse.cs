using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace Matthew
{
    [Serializable]
    public class WaitResponse
    {
        [SerializeField] private UnityEvent response;

        [SerializeField] private float time;

        public WaitResponse(float time, UnityEvent response)
        {
            this.response = response;
            this.time = time;
        }

        public Action OnDone { get; set; }

        public void Invoke(MonoBehaviour mb)
        {
            mb.StartCoroutine(WaitForTime());
        }

        private IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(time);
            response.Invoke();
            OnDone.Invoke();
        }
    }
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(WaitResponse))]
    public class WaitResponseEditor : PropertyDrawer
    {
        private SerializedProperty _responseProperty;
        private SerializedProperty _timeProperty;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            _responseProperty = property.FindPropertyRelative("response");
            _timeProperty = property.FindPropertyRelative("time");
            var responseheight = EditorGUI.GetPropertyHeight(_responseProperty);
            var timeheight = EditorGUI.GetPropertyHeight(_timeProperty);

            return responseheight + timeheight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _timeProperty = property.FindPropertyRelative("time");

            _responseProperty = property.FindPropertyRelative("response");
            var timeheight = EditorGUI.GetPropertyHeight(_timeProperty);
            var responseheight = EditorGUI.GetPropertyHeight(_responseProperty);
            position.height = timeheight;
            //shrink the rect
            EditorGUI.PropertyField(position, _timeProperty);
            position.y += timeheight;
            position.height = responseheight;
            EditorGUI.PropertyField(position, _responseProperty);
        }
    }
#endif
}