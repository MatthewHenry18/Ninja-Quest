using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner confiner;

    [SerializeField] Direction direction;
    [SerializeField] float additivePos = 2;      //amount of space to jump on transition
    enum Direction {Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    //Move the player past the transition colider boundary
    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                newPos.y += additivePos;
                break;
            case Direction.Down:
                newPos.y -= additivePos;
                break;
            case Direction.Left:
                newPos.x -= additivePos;
                break;
            case Direction.Right:
                newPos.x += additivePos;
                break; 
        }
        player.transform.position = newPos;
    }
}
