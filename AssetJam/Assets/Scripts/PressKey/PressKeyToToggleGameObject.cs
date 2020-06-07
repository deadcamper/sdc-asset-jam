using UnityEngine;

namespace DHG.Helpers
{
    public class PressKeyToToggleGameObject : MonoBehaviour
    {
        public KeyCode key;
        public GameObject gameObj;

        private void Update()
        {
            if (Input.GetKeyDown(key) && gameObj)
            {
                gameObj.SetActive(!gameObj.activeSelf);
            }
        }
    }
}