using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppController
{
    public class AppController : Singleton<AppController>
    {
        protected override void AwakeSingleton()
        {
            return;
        }
    }
}