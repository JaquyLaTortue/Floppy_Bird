﻿using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;

    public GameObject Bird { get; set; }

    private BirdCollisions _birdCollision;

    private void Start()
    {
        _birdCollision = Bird.GetComponent<BirdCollisions>();
    }

    private void Update()
    {
        if (transform.position.x <= -11)
        {
            Destroy(gameObject);
        }
        else if (!_birdCollision.Alive)
        {
            return;
        }
        else
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
