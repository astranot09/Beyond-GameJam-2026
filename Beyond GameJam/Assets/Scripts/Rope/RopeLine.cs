using UnityEngine;
using UnityEngine.UIElements;

public class RopeLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject kakak;
    [SerializeField] private GameObject dog;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, kakak.transform.position);
        lineRenderer.SetPosition(1, dog.transform.position);
    }
}
