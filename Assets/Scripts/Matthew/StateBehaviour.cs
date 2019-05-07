using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matthew
{
    public interface IStateBehaviour
    {
        IContext Context { get; }
    }

    public abstract class StateBehaviour : MonoBehaviour, IStateBehaviour
    {
        public abstract IContext Context { get; }
    }
}