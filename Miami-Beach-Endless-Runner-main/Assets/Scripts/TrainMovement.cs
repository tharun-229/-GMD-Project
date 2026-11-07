using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}