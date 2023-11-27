using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootstepAudioController : MonoBehaviour
{
    public Transform leftLeg;
    RaycastHit hit;
    Mesh mesh;
    Material hitMaterial;
    public Material[] checkMaterials;
    public AudioClip[] checkClips;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(leftLeg.position, Vector3.down, Color.red);

        if(Physics.Raycast(leftLeg.position, Vector3.down, out hit))
        {
            MeshCollider meshCollider = hit.collider as MeshCollider;

            Renderer renderer = hit.collider.GetComponent<Renderer>();

            if (meshCollider)
            {
                mesh = meshCollider.sharedMesh;

                int[] hitTriangle = new int[]
                {
                    mesh.triangles[hit.triangleIndex * 3 + 0],
                    mesh.triangles[hit.triangleIndex * 3 + 1],
                    mesh.triangles[hit.triangleIndex * 3 + 2]
                };

                //for(int i = 0; i < hitTriangle.Length; i++)
                //{
                //    Debug.Log("Triangle Index: " + hit.triangleIndex + "Number:" + i + "Hit Triangle Index: " + hitTriangle[i]);
                //}

                for(int i = 0; i < mesh.subMeshCount; i++)
                {
                    int[] subMeshTriangles = mesh.GetTriangles(i);

                    for(int j = 0; j < subMeshTriangles.Length; j+= 3)
                    {
                        if (subMeshTriangles[j + 0] == hitTriangle[0] && subMeshTriangles[j + 1] == hitTriangle[1] && subMeshTriangles[j + 2] == hitTriangle[2])
                        {
                            hitMaterial = renderer.materials[i];
                        }
                    }
                }
            }
        }
        Debug.Log(hitMaterial.name);

        for( int i = 0; i < checkMaterials.Length; i++)
        {
            if (hitMaterial.name.Contains(checkMaterials[i].name))
            {
                audioSource.clip = checkClips[i];
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }

    }
}
