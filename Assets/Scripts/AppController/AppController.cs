using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppController
{
    /// <summary>
    /// Handles the persistance of the AppController object.
    /// Really just a container that inherits from Singleton.cs (Util)
    /// 
    /// AppController is an object that persists thoughout all of the scenes.
    /// Often called a "GameController" by other Unity devs - GameController in this project is different.
    /// 
    /// Because this is persistent, the MonoBehaviours on AppController don't have to be static.
    /// </summary>
    public class AppController : Singleton<AppController>
    {
        protected override void AwakeSingleton()
        {
            return;
        }
    }
}