using DG.Tweening;
using UnityEngine;
using ZSerializer;

public class WorkTable : PersistentMonoBehaviour
{
    [NonZSerialized][SerializeField] WorkZone zoneManager;
    [NonZSerialized][SerializeField] CircleCanvas circleCanvas;
    [NonZSerialized][SerializeField] Worker worker;
    [NonZSerialized][SerializeField] GameObject[] visuals;
    [NonZSerialized] public AudioSource audioSource;

    [HideInInspector][SerializeField] int visualIndex = 0;
    [HideInInspector][SerializeField] float productionTime = 12f;
    
    float percentage = 0.02f;

    /*private void Start()
    {
        visuals[0].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }*/
    public override void OnPostLoad()
    {
        visuals[0].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }

    Sequence CreateGemSequence()
    {
        return DOTween.Sequence()
            //.AppendCallback(() => audioSource.Play())
            .Append(circleCanvas.AppearAndFill(productionTime))
            .AppendCallback(() => worker.GoToNextPosition())
            //.OnKill(() => audioSource.Stop())
            .SetDelay(0.2f);
    }

    void CreateGem()
    {
        int gem = Random.Range(0, 3);
        CreateGemSequence()
            .OnComplete(() =>
            {
                //audioSource.Stop();
                if (zoneManager.AnyRequestForThisGem(gem))
                {                   
                    zoneManager.GetPendingRequestsOf(gem).Dequeue().counter.ReceiveGem(gem);
                }
                else
                {
                    zoneManager.AddGemToInventory(gem);
                }
            })
            .Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == worker.gameObject)
        {
            worker.ChangeTag("Worker");
            
            DOTween.Sequence()
                .Append(other.transform.DOLookAt(transform.position, 1f, AxisConstraint.Y))
                .AppendCallback(() => worker.PlayAnimation());

            //worker.PlayAnimation();

            if (zoneManager.CheckForPendingRequests()) // There are pending requests
            {
                CounterRequest counterRequest = zoneManager.GetRandomPendingRequest();
                CreateGemSequence().Append(counterRequest.counter.ReceiveGem(counterRequest.gem));
            }
            else // No pending requests
            {
                CreateGem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == worker.gameObject)
        {
            worker.StopAnimation();
        }
    }

    public void UpdateAttributes()
    {
        productionTime -= productionTime * percentage;
        GameController.IncreaseGemsPrices(1.1f);
        Debug.Log("ProductionTime: " + productionTime);
    }

    public void DoMajorUpgrade()
    {
        if (visualIndex >= visuals.Length)
        {
            Debug.LogError("ERROR: visual index out of length");
        }

        visuals[visualIndex++].SetActive(false);
        visuals[visualIndex].SetActive(true);
    }
}
