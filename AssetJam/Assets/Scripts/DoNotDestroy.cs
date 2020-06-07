using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes the game object attached to this component and immediately marks it as "Do Not Destroy", then cleans itself up.
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
