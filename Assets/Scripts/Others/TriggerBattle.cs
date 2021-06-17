using UnityEngine;
using UnityEngine.Events;

public class TriggerBattle : MonoBehaviour
{
    public UnityAction OnStartBattle;
    private bool isStarted = false;
    [SerializeField] private GameObject bossGates;

    private void Awake()
    {
        isStarted = false;
        gameObject.SetActive(true);
        bossGates.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isStarted && other.gameObject.layer != LayerMask.NameToLayer("CameraCollision") && other.gameObject.layer != this.gameObject.layer && other.gameObject.tag == "Player")
        {
            isStarted = true;
            OnStartBattle?.Invoke();
            bossGates.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
