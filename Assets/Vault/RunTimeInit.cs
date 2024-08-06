using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTimeInit
{

    [RuntimeInitializeOnLoadMethod]
    private static void OnProjectInitialized()
    {
        var controllerRegisterer = Object.FindObjectOfType<ContextController>();

        if (controllerRegisterer == null)
        {
            var obj = Resources.Load<ContextController>("ProjectContextController");
            if (obj)
            {
                controllerRegisterer = Object.Instantiate(obj);
                Object.DontDestroyOnLoad(controllerRegisterer.gameObject);
            }
            else
            {
                Debug.LogError(" [Context Controller] : ProjectContextController is not found");
            }
        }
        else
        {
            Object.DontDestroyOnLoad(controllerRegisterer.gameObject);
        }
    }
}
