using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingPlatformController : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public bool isActive;
    public float timer;

    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        isActive = false;
        destination = end.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            _Move();
        }
        
    }

    private void _Move()
    {
        var destinationX = (destination.x > 0)
            ? start.position.x + Mathf.PingPong(timer, destination.x)
            : start.position.x;

        var destinationY = (destination.y > 0)
            ? start.position.y + Mathf.PingPong(timer, destination.y)
            : start.position.y;

        transform.position = new Vector3(destinationX, destinationY, 0.0f);
    }

}
