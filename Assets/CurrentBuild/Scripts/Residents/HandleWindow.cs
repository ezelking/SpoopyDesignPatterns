using UnityEngine;
using System.Collections;

public class HandleWindow : MonoBehaviour {

    [SerializeField]
    private WindowAction _windowAction;
    [SerializeField]
    private AreaTaunt _areaTaunt;
    [SerializeField]


    public void ExecuteWindow()
    {
        _windowAction.activated = true;
        _areaTaunt.callBack = ResetWindowInteraction;
    }

    public void ResetWindowInteraction()
    {
        if (!_windowAction.ready)
        {
            _windowAction.AI_Hit = true;
            _areaTaunt.TauntReady = false;
        }
    }
}
