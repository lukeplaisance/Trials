using System.Collections.Generic;
using UnityEngine;

namespace Matthew
{
    /// <summary>
    ///     use this class to make a sequence of events happen after a specified time
    /// </summary>
    public class WaitResponseBehaviour : MonoBehaviour
    {
        private int _currentIndex;
        public List<WaitResponse> responses;

        public void Execute()
        {
            //for every response
            foreach (var response in responses)
                //when it is done executing
                response.OnDone += () =>
                {
                    //increment the current index 
                    _currentIndex++;
                    //and if the current index is not past the last item
                    if (_currentIndex + 1 <= responses.Count)
                        //call the next function inside the OnDone
                        responses[_currentIndex].Invoke(this);
                };

            responses[_currentIndex].Invoke(this);
        }
    }
}