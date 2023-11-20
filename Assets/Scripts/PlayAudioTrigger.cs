using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioTrigger : MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private GameObject audioObject;
    [SerializeField] private float timeToDestroy = 10f;

    //private FMODUnity.StudioEventEmitter eventEmitterRef;

    //void Awake()
    //{
    //    eventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>();
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound(path, audioObject);
            //PlaySound();
            //Destroy(audioObject);
            StartCoroutine(DestroyObject());
        }
    }

    private void PlaySound(string path, GameObject audioObject)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, audioObject.transform.position);
        Debug.Log(path + "played");
        
    }

    //private void PlaySound()
    //{
    //    eventEmitterRef.Play();
    //    Debug.Log(eventEmitterRef);
    //}

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this.gameObject);
    }
}
