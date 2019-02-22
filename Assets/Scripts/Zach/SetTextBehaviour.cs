using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zach
{
    public class SetTextBehaviour : MonoBehaviour
    {
        public StringVariable mystr;

        private Text _tc;
        // Use this for initialization
        void Start()
        {
            _tc = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            _tc.text = (string)mystr.Value;
        }
    }
}