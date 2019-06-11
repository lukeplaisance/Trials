using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    [CreateAssetMenu(menuName = "Variables/Audio")]
    public class AudioVariable : Variable
    {
        [SerializeField] private AudioClip AudioOne;
        [SerializeField] private AudioClip AudioTwo;
        public override object Value
        {
            get { return AudioOne; }

            set { AudioOne = (AudioClip) value; }
        }

        public override object MaxValue
        {
            get { return AudioTwo; }
            set { AudioTwo = (AudioClip) value; }
        }
    }
}