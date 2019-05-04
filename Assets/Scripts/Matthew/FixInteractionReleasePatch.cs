using System.Linq; 
namespace Matthew
{
    public class FixInteractionReleasePatch : UnityEngine.MonoBehaviour
    {
        public System.Collections.Generic.List<Luke.InteractionBehaviour> interactableBehaviours;
        /// <summary>
        /// grab all InteractionBehaviours that are in the children of this gameObject
        /// add the ReleaseInteraction method from that InteractionBehaviour to its InteractStopResponse callback
        /// </summary>
        void Start ()
        {
            interactableBehaviours = GetComponentsInChildren<Luke.InteractionBehaviour>().ToList();            
            interactableBehaviours.ForEach(ib => ib.InteractStopResponse.AddListener(ib.ReleaseInteraction));
            interactableBehaviours.ForEach(ib => ib.OnTriggerStayResponse.AddListener(ib.SetInteractionToThis));

        }
	
 
    }
}
