using System;
using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakePart snakePartPrefab;
    [SerializeField] private SnakePart startingSnakePart;
    [SerializeField] private Transform snakeTurret;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float snakeStartingLenght;
    [SerializeField] private float snakeSpeed;
    [SerializeField] private float fireRate;

    private Vector3 moveDirection = Vector3.forward;
    private Quaternion targetRotation = Quaternion.identity;
    private bool gameOver = false;
    private SnakePart mostRecentSnakePart;

    public event Action OnCollided;

    private void Start()
    {
        mostRecentSnakePart = startingSnakePart;
    }

    private void Awake()
    {
        Enemy.OnCollidedWithEnemy += OnCollidedWithEnemy;
        Fruit.OnCollidedWithFruit += OnCollidedWithFruit;
    }

    private void OnCollidedWithFruit()
    {
        EatFruit();
    }

    private void OnCollidedWithEnemy()
    {
        gameOver = true;
    }

    void Update()
    {
        MoveSnake();
        Shoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollided?.Invoke();
    }

    private void MoveSnake()
    {
        transform.position = transform.position + (moveDirection * snakeSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            moveDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector3.back;
        }

        targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = targetRotation;
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet snakeBullet = Instantiate(bullet);
            snakeBullet.transform.position = snakeTurret.position;
            snakeBullet.transform.SetParent(null);
            snakeBullet.SetDirection(targetRotation * Vector3.forward);
        }
    }

    private void EatFruit()
    {
        // Add a new part to the snake
        AddPart();
    }

    private void AddPart()
    {
        SnakePart newSnakePart = Instantiate(snakePartPrefab);
        newSnakePart.transform.position = mostRecentSnakePart.SnakePartOffset.position;
        mostRecentSnakePart = newSnakePart;
    }
}
