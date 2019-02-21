using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    [CreateAssetMenu(menuName = "Variables/String")]
    public class StringVariable : Variable
    {
        [SerializeField] private string entryOne;
        [SerializeField] private string entryTwo;

        public override object Value
        {
            get { return entryOne; }
            set { entryOne = (string)value; }
        }

        public override object MaxValue
        {
            get { return entryTwo; }
            set { entryTwo = (string)value; }
        }
    }
}