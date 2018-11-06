using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class DogWhistle : MonoBehaviour {
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private NavMeshAgent agent;

    
   [SerializeField]
   private AudioClip whistleSound;

    private FollowPath fp;
    private AudioSource m_AudioSource;


	
	// Update is called once per frame
    private void Awake() {
        fp = GetComponent<FollowPath>();
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = whistleSound;

    }

	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(fp){
                    fp.interruptPosCall(hit);
                } else{
                    agent.SetDestination(hit.point);
                }
            }
        }


	}
}
