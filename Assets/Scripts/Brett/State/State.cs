using System;

namespace Assets.Scripts.Brett
{
    [Serializable]
    public abstract class State
    {
        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void Update(Context c, ConditionScriptable conditionScriptable);
    }
}