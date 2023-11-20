using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.AssetImporters;
using UnityEngine;

public class ObjectAudioController : MonoBehaviour
{

    public bool isStatic;
    public float radius;
    public GameObject textGO;
    AudioSource anvilSource;

    // Start is called before the first frame update
    void Start()
    {
        anvilSource = GetComponent<AudioSource>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if(isStatic)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    textGO.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anvilSource.Play();
                    }
                    break;
                }
                else
                {
                    textGO.SetActive(false);
                }
            }
        }

       
    }

    public void OnCollisionEnter(Collision collision)
    {
      AudioSource source = GetComponent<AudioSource>();
      source.Play();

      if(!isStatic)
        {
            if(!anvilSource.isPlaying)
            {
                anvilSource.Play();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
