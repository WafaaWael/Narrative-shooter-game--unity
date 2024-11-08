using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object>{}
public class GameEventlistener : MonoBehaviour
{
    public GameEvent gameEvent;
    public CustomGameEvent response;
    private void OnEnable()
    {
        gameEvent.RegistListener(this);
    }
    private void OnDisable()
    {
        gameEvent.Unregisterlistener(this);
    }
    public void OnEventRaised(Component sender,object data)
    {
        response.Invoke(sender,data);
    }
}
