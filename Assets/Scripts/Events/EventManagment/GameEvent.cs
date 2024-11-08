using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptables/GameEvent")]
public class GameEvent : ScriptableObject
{
  public List<GameEventlistener> listeners= new List<GameEventlistener>();

    public void Raise(Component sender, object data)
    {
        for(int i=0; i<listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender,data);
        }
    }

    public void RegistListener(GameEventlistener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    public void Unregisterlistener(GameEventlistener listener)
    {
        if(listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
