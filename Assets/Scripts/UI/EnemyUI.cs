using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Canvas enemyUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Camera targetCamera;

    private void LateUpdate()
    {
        FaceTarget();
    }

    public void FaceTarget()
    {
        enemyUI.transform.LookAt(transform.position + targetCamera.transform.forward);
    }
}
