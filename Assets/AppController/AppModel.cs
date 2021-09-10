using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppController
{
    /// <summary>
    /// Want to pass information between scenes? Use this.
    /// Is really just a container for scene models: classes containing information relevant to
    /// certain scenes.
    /// </summary>
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