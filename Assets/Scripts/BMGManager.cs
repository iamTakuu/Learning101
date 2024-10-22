using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMGManager : MonoBehaviour
{   //Create an Audio Source and List of Clips/Songs to use later.
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _audioClips;
    
    // Stack to hold all songs as the game goes. This will be used to make sure that
    // a new song is always played, as once you remove something from a stack, it's gone.
    // https://www.geeksforgeeks.org/c-sharp-stack-with-examples/
    private Stack<AudioClip> _stack;
    private void Awake()
    {
        // Initialise the Stack in memory.
        _stack = new Stack<AudioClip>();
        if (_audioClips != null)
        {
            foreach (var clip in _audioClips)
            {
                _stack.Push(clip); // Push each clip in here.
            }
        }
    }

    private void Start()
    {
        if (_source != null && _stack != null)
        {
            // Add the last clip from list, then play!
            _source.clip = _stack.Pop();
            _source.Play();
        }
        
    }
}
