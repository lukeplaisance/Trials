using Matthew;
using UnityEngine;

namespace Zach
{

    public class NarrationAudioBehaviour : MonoBehaviour
    {
        public AudioSource NarrationSource;
        private GlobalBlackboard globalBlackboard;
        public void SetAudioClip(AudioVariable audioVariable)
        {


            NarrationSource.clip = (AudioClip)audioVariable.Value;
#if BLIPPSOUNDS
            globalBlackboard.PlayFMODAudio("event:/"+NarrationSource.clip.name);
#endif
            NarrationSource.Play();
 

        }

    }
}