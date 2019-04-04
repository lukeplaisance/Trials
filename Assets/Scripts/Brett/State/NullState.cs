using System;

namespace Assets.Scripts.Brett
{
    public class NullState : State
    {
        public override void OnEnter()
        {
            throw new NotImplementedException();
        }

        public override void OnExit()
        {
            throw new NotImplementedException();
        }

        public override void Update(Context c, ConditionScriptable conditions)
        {
            throw new NotImplementedException();
        }
    }
}