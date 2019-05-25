using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private const int Z_MINIMO = 10;
    private const int Z_MAXIMO = 200;

    void Update()
    {
        int speed = 0;

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z > Z_MINIMO)
        {
            speed = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.z < Z_MAXIMO)
        {
            speed = -1;
        }

        transform.Translate(Vector3.forward * speed);
    }
}
