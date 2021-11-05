using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SetSortOrder : MonoBehaviour
    {
        public string sortLayer;

        void Awake()
        {
            GetComponent<MeshRenderer>().sortingLayerName = sortLayer;
        }
    }
}