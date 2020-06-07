using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Space space = Space.World;
    public Vector3 eulerRotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulerRotationSpeed * Time.deltaTime, space);
    }
}
