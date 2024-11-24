using UnityEngine;

public class Injector : MonoBehaviour
{
    [SerializeField] private MagicRockParent _rockService;
    private PaintManager _paintManager;

    private void Awake()
    {
        _paintManager = new(_rockService);
    }
}
