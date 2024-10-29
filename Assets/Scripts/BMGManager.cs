using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMGManager : MonoBehaviour
{   //Create an Audio Source and List of Clips/Songs to use later.
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _audioClips;
    
    // Queue to hold all songs as the game goes.
    private Queue<AudioClip> _queue;
    private void Awake()
    {
        // Initialise the Queue in memory.
        _queue = new Queue<AudioClip>();
        if (_audioClips != null)
        {
            foreach (var clip in _audioClips)
            {
                _queue.Enqueue(clip); // Queue each clip in here.
            }
        }
    }

    private void Start()
    {
        if (_source != null && _queue != null)
        {
            // Add the first clip from list, then play!
            _source.clip = _queue.Dequeue();
            _source.Play();
            StartCoroutine(PlayAudio());
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
            StartCoroutine(PlayAudio());
        }
    }


    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(_source.clip.length);
        _queue.Enqueue(_source.clip);
        _source.clip = _queue.Dequeue();
        _source.Play();
        StartCoroutine(PlayAudio());
    }
}
