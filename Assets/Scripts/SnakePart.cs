using UnityEngine;

public class SnakePart : MonoBehaviour
{
    [SerializeField] Transform snakePartOffset;

    public Transform SnakePartOffset => snakePartOffset;
}
