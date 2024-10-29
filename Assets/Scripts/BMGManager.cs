using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMGManager : MonoBehaviour
{  
    // https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static BMGManager Instance { get; set; }
    
    //Create an Audio Source and List of Clips/Songs to use later.
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _audioClips;
    
    // Queue to hold all songs as the game goes.
    private Queue<AudioClip> _queue;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
        // Initialise the Queue in memory.
        _queue = new Queue<AudioClip>();
        if (_audioClips != null)
        {
            foreach (var clip in _audioClips)
            {
                _queue.Enqueue(clip); // Queue each clip in here.
            }
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (_source != null && _queue != null)
        {
            // Add the first clip from list, then play!
            _source.clip = _queue.Dequeue();
            _source.Play();
            StartCoroutine(PlayClip());
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextTrack();
        }
    }

    private void NextTrack()
    {
        if (_source && _queue != null)
        {
            StopAllCoroutines();
            _queue.Enqueue(_source.clip);
            _source.clip = _queue.Dequeue();
            _source.Play();
            StartCoroutine(PlayClip());
        }
    }


    private IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(_source.clip.length);
        _queue.Enqueue(_source.clip);
        _source.clip = _queue.Dequeue();
        _source.Play();
        StartCoroutine(PlayClip());
    }
}
