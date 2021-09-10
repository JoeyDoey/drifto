using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppController
{
    public class AppModel : MonoBehaviour
    {
        public GameModel gameModel;
    }

    [System.Serializable]
    public class GameModel
    {
        public bool skipMenu = false;
    }
}