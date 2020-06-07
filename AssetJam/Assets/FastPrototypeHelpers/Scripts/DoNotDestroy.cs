using UnityEngine;

namespace DHG.Helpers
{
    /// <summary>
    /// Takes the game object attached to this component and immediately marks it as "Do Not Destroy", then cleans the script up.
    /// </summary>
    public class DoNotDestroy : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Destroy(this);
        }
    }
}
