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
    // https://www.geeksforgeeks.org/c-sharp-queue-with-examples/
    private Queue<AudioClip> _queue;

    private void OnEnable()
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
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        PlayNextTrack();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayNextTrack();
        }
    }
    private void QueueAndPlayTrack()
    {
        if (_source.clip)
        {
            _queue.Enqueue(_source.clip);
        }
        _source.clip = _queue.Dequeue();
        _source.Play(); 
    }
    private void PlayNextTrack()
    {
        StopAllCoroutines();
        QueueAndPlayTrack();
        StartCoroutine(TrackCurrentSong());  
    }
    private IEnumerator TrackCurrentSong()
    { 
        yield return new WaitForSeconds(_source.clip.length);
        QueueAndPlayTrack();
        StartCoroutine(TrackCurrentSong());
    }

}
