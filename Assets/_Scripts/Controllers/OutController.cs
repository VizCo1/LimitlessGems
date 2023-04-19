using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarExit2"))
        {
            gameController.ClientOut(other.transform.parent.gameObject);
        }
    }
}
