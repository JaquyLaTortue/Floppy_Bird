using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [Header("Paralax Bounds")]
    [SerializeField]
    private Transform _startPosition;

    [SerializeField]
    private Transform _endPosition;

    [Header("Paralax Elements")]
    [SerializeField]
    private List<GameObject> _paralaxElements = new List<GameObject>();

    [Header("Paralax Speed")]
    [SerializeField]
    private float _speed = 1;

    bool _isPlaying = false;

    private void Update()
    {
        if (_isPlaying)
        {
            for (int i = 0; i < _paralaxElements.Count; i++)
            {
                GameObject currentElement = _paralaxElements[i];
                if (currentElement.transform.position.x <= _endPosition.position.x)
                {
                    currentElement.transform.position = _startPosition.position;
                }
                else
                {
                    currentElement.transform.Translate(Vector3.left * _speed * Time.deltaTime);
                }
            }
        }
    }

    public void StartParalax()
    {
        _isPlaying = true;
    }

    public void StopParalax()
    {
        _isPlaying = false;
    }
}
