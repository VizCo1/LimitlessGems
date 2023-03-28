using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] Zone zone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            zone.MoveAgentToSpot(other.GetComponent<AgentBase>());

            /*switch (this.name)
            {
                case "KeyCounter":
                    zone.GetComponent<CounterZone>().MoveAgentToSpot(other.GetComponent<AgentBase>());
                    break;

                case "KeyParking":
                    break;

                default:
                    break;
            }*/
            
        }
    }
}
