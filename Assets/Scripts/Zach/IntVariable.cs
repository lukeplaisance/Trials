using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : Variable
    {
        [SerializeField] private int value;
        [SerializeField] private int maxValue;
        public override object Value
        {
            get
            {
                return value;
            }
            set
            {
                value = (int)value;
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
                maxValue = (int)value;
            }
        }
    }
}