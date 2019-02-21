using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    [CreateAssetMenu(menuName = "Variables/Float")]
    public class FloatVariable : Variable
    {
        [SerializeField] private float value;
        [SerializeField] private float maxValue;
        public override object Value
        {
            get
            {
                return value;
            }
            set
            {
               value = (float)value;
               onValueChanged.Invoke(this);
            }
        }

        public override object MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = (float)value;
            }
        }
    }
}