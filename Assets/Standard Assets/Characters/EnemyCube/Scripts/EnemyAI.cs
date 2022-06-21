using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent _agent;
    private static bool _gameIsPaused;

    public bool gameOver = false;

    public GameObject myBall;

    // Start is called before the first frame update
    //private Vector3 _sizeOfCube;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_myBall = GetComponent<MyBall>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(player.position);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameIsPaused = !_gameIsPaused;
            //PauseGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameOver = true;
            transform.localScale = new Vector3(2f, 2f, 2f) * 1.2f;
            gameObject.GetComponent<Renderer>().material.color = Color.red;

            //Debug.Log("Game-Over");
            KillBall();
        }
    }

    public void KillBall()
    {
        myBall.SetActive(false);
        //Debug.Log("myball killed");
    }

}