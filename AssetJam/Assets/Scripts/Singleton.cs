using System.Collections.Generic;
using UnityEngine;

namespace DHG.Helpers
{
    /// <summary>
    /// The Singleton is a component class that's made to only have one active instance at a time, available to use across the game.
    /// 
    /// This acts similar to the Singleton design pattern, except for two *major* limitations:
    /// - Unity has no way of automatically spawning the first singleton, meaning it must be spawned before retrieval.
    /// - The 'singleton' rule applies only to the special "identifier" string, and not to the class.
    /// - Two Singleton components with the same string will be considered the same Singleton, and one will self-destruct
    /// 
    /// </summary>
    public class Singleton : MonoBehaviour
    {
        public string id = "";

        private static Dictionary<string, Singleton> _idLookup = new Dictionary<string, Singleton>();

        // Start is called before the first frame update
        void Awake()
        {
            id = id.Trim();
            if (id.Length == 0)
            {
                Debug.LogError($"Singleton id cannot be empty or whitespace. This Singleton (gameobject={name}) will not work.");
            }

            if (_idLookup.ContainsKey(id) && _idLookup[id] != this)
            {
                Debug.Log($"Singleton discovered duplicate by id ({id}). Destroying self");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"Singleton established by id ({id})");
                _idLookup[id] = this;
            }
        }

        private void OnDestroy()
        {
            if (_idLookup.ContainsKey(id))
            {
                if (_idLookup[id] == this)
                {
                    _idLookup.Remove(id);
                }
            }
        }
    }
}