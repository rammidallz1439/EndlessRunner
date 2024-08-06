using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EventManager : IController,ITick
    {

        public bool LimitProcess = false;
        public int QueueTime = 20;

        private static EventManager _instance = null;
        private static bool isDestroyed = false;

        public delegate void EventDelegate<T>(T e) where T : GameEvent;
        public delegate void EventDelegate(GameEvent e);

        private readonly Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();
        private readonly Dictionary<System.Delegate, EventDelegate> delegateLookUp = new Dictionary<System.Delegate, EventDelegate>();
        private readonly Dictionary<System.Delegate, bool> oncelookUp = new Dictionary<System.Delegate, bool>();
        public readonly Queue _queue = new Queue();

        public static EventManager Instance
        {
            get
            {
                if (!isDestroyed && _instance == null)
                {
                    _instance = new EventManager();
                }
                return _instance;
            }
        }

        public bool IsDestroyed
        {
            get
            {
                return isDestroyed;
            }
            set
            {
                isDestroyed = value;
            }
        }

        public EventDelegate AddDelegate<T>(EventDelegate<T> del) where T : GameEvent
        {
            if (delegateLookUp.ContainsKey(del))
            {
                return null;
            }
            EventDelegate internalDel = (e) => del((T)e);
            delegateLookUp[del] = internalDel;

            EventDelegate tempDel = null;
            if (delegates.TryGetValue(typeof(T),out tempDel))
            {
                delegates[typeof(T)] = tempDel += internalDel;

            }
            else
            {
                delegates[typeof(T)] = internalDel;

            }

            return internalDel;
        }


        public void AddListener<T>(EventDelegate<T> del) where T : GameEvent
        {
            AddDelegate<T>(del);
        }
        public void AddListenerOnce<T>(EventDelegate<T> del) where T : GameEvent
        {
            EventDelegate result = AddDelegate<T>(del);
            if (result !=null)
            {
                oncelookUp[result] = true;
            }
        }
        public void RemoveListener<T>(EventDelegate<T> del) where T : GameEvent
        {
            if (delegateLookUp.TryGetValue(del,out EventDelegate interalDelegate))
            {
                if (delegates.TryGetValue(typeof(T), out EventDelegate tempDel))
                {
                    tempDel -= interalDelegate;
                    if (tempDel == null)
                    {
                        delegates.Remove(typeof(T));
                    }
                    else
                    {
                        delegates[typeof(T)] = tempDel;
                    }
                }
                delegateLookUp.Remove(del);
            }
        }

        private void RemoveAll()
        {
            delegates.Clear();
            delegateLookUp.Clear();
            oncelookUp.Clear();
        }

        public void TriggerEvent(GameEvent e)
        {
            if (delegates.TryGetValue(e.GetType(),out EventDelegate del))
            {
                del.Invoke(e);
            }
            else
            {
                Debug.Log("Event:" + e.GetType() + "has no listeners");
            }
        }


        public bool QueueEvent(GameEvent evt)
        {
            if (!delegates.ContainsKey(evt.GetType()))
            {
                return false;
            }
            _queue.Enqueue(evt);
            return true;
        }


        #region interfacemethods
        public void OnInitialize()
        {
           
        }

        public void OnUpdate()
        {
            DateTime startTime = DateTime.Now;
            while (_queue.Count > 0)
            {
                if (LimitProcess)
                {
                    if ((DateTime.Now -startTime).Milliseconds > QueueTime)
                    {
                        return;
                    }
                }
                GameEvent evnt = _queue.Dequeue() as GameEvent;
                TriggerEvent(evnt);
            }
        }

        public void RegisterListener()
        {
        }

        public void Release()
        {
            
            _queue.Clear();
            RemoveAll();
            isDestroyed = true;
        }

        public void RemoveListener()
        {
        }

        #endregion
    }
}

