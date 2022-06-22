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
    [SerializeField] private GameObject gameOverPanel;
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
            gameObject.GetComponent<Renderer>().material = newMaterialRef;
            _agent.speed = 0f;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            m_AudioSource.clip = gameOverSound;
            m_AudioSource.Play();
            KillBall();
        }
    }

    public void KillBall()
    {
        gameOver = true;
        myBall.SetActive(false);
        StartCoroutine(GameOver());
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

    IEnumerator  GameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverPanel.SetActive(true);
    }

}