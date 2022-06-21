using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (AudioSource))]
public class EnemyAI : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent _agent;
    private static bool _gameIsPaused;
    public Material newMaterialRef;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip snowWalk;
    
    
    private AudioSource m_AudioSource;

    public bool gameOver = false;

    public GameObject myBall;

    // Start is called before the first frame update
    //private Vector3 _sizeOfCube;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        m_AudioSource = GetComponent<AudioSource>();
        //_myBall = GetComponent<MyBall>();
        //WalkAudio();
        
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameOver = true;
            transform.localScale = new Vector3(2f, 2f, 2f) * 1.2f;
            //gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.GetComponent<Renderer>().material = newMaterialRef;
            transform.localPosition = new Vector3(-13f, -8f, -8f);
            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
            //Debug.Log("Game-Over");
            m_AudioSource.clip = gameOverSound;
            m_AudioSource.Play();
            KillBall();
        }
    }

    public void KillBall()
    {
        gameOver = true;
        myBall.SetActive(false);
        //Debug.Log("myball killed");
    }

    void WalkAudio()
    {
        if (gameOver == false)
        {
            m_AudioSource.clip = snowWalk;
            m_AudioSource.Play();
        }
        else
        {
            m_AudioSource.clip = snowWalk;
            m_AudioSource.Stop();
        }
            
    }

}