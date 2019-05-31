using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// use this class to make a sequence of events happen after a specified time
/// </summary>
public class WaitResponseBehaviour : MonoBehaviour
{
    private int _currentIndex;
    public List<WaitResponse> Responses;


    public void Execute()
    {
        //for every response
        foreach (var response in Responses)
            //when it is done executing
            response.OnDone += () =>
            {
                //increment the current index 
                _currentIndex++;
                //and if the current index is not past the last item
                if (_currentIndex + 1 <= Responses.Count)
                    //call the next function inside the ondone
                    Responses[_currentIndex].Invoke(this);
            };

        Responses[_currentIndex].Invoke(this);
    }
}