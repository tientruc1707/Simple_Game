using UnityEngine;

public class FlyObject : MonoBehaviour
{
    [SerializeField] private Transform _flyObject;
    private Vector3 startPos;
    private float speed = 1f;
    private float boundary = 2f;
    private int direction = 1; // 1: đi phải, -1: đi trái

    void Start()
    {
        _flyObject = GetComponent<Transform>();
        startPos = _flyObject.position;
    }

    void Update()
    {
        _flyObject.position += Vector3.right * direction * speed * Time.deltaTime;

        if (_flyObject.position.x - startPos.x > boundary)
        {
            direction = -1;
        }
        else if (_flyObject.position.x - startPos.x < -boundary)
        {
            direction = 1;
        }
    }
}
