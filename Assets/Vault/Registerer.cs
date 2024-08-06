using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
public abstract class Registerer : MonoBehaviour
{
        public List<IController> Controller = new List<IController>();
        public List<ITick> Tick = new List<ITick>();
        public List<IFixedTick> FixedTick = new List<IFixedTick>();


        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
            AddListeners();
            CallInitialze();
        }

        private void Update()
        {
            CallUpdate();
        }
        private void FixedUpdate()
        {
            CallFixedUpdate();
        }
        public abstract void OnAwake();
        public abstract void OnStart();

        public void RegisterController(IController controller)
        {
            if (!Controller.Contains(controller))
            {
                Controller.Add(controller);
                AddRespectiveTicks(controller);
            }
            else
            {
                Debug.LogError("controller not added or not the right type of controller");
            }
        }
        public void AddRespectiveTicks(IController controller)
        {
            if (controller is ITick)
            {
                Tick.Add((ITick)controller);
            }
            if (controller is IFixedTick)
            {
                FixedTick.Add((IFixedTick)controller);
            }
        }

        public void CallInitialze()
        {
            foreach (IController Icontroller in Controller)
            {
                Icontroller.OnInitialize();
            }
        }
       public void CallUpdate()
        {
            foreach (ITick tick in Tick)
            {
                tick.OnUpdate();
            }
        }
        public void CallFixedUpdate()
        {
            foreach (IFixedTick fixedTick in FixedTick)
            {
                fixedTick.OnFixedUpdate();
            }
        }
        public void AddListeners()
        {
            foreach (IController Icontroller in Controller)
            {
                Icontroller.RegisterListener();
            }
        }
    }
}
