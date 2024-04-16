using UnityEngine;

public class DifferencesPair : MonoBehaviour
{
    [SerializeField] private FindDifferences First;
    [SerializeField] private FindDifferences Second;

    [SerializeField] private GameObject PrefabIconSuccess;
    private bool _isNeedCreateIcon;

    private void Start()
    {
        FindDifferences.OnDifferenceFound += OnDifferenceFound;
        _isNeedCreateIcon = true;
    }

    private void OnDifferenceFound(GameObject obj)
    {
        if (obj == First.gameObject)
        {
            Second.SetDifferenceFound(true);
        }

        if (obj == Second.gameObject)
        {
            First.SetDifferenceFound(true);
        }

        if (_isNeedCreateIcon && First.IsDifferenceFound() && Second.IsDifferenceFound())
        {
            CreateIcon(First.transform);
            CreateIcon(Second.transform);
            _isNeedCreateIcon = false;
        }
    }

    private void CreateIcon(Transform positionDifference)
    {
        var firstIcon = Instantiate(PrefabIconSuccess, positionDifference);
        firstIcon.transform.position = positionDifference.position;
    }

    private void OnDestroy()
    {
        FindDifferences.OnDifferenceFound -= OnDifferenceFound;
    }
}
