using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private Vector3 moveDirection;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (moveDirection * bulletSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 shootingDirection)
    {
        moveDirection = shootingDirection;
    }
}
