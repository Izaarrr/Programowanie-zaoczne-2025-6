using UnityEngine;

public class GunButtons : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GunStats[] guns;
    [SerializeField] GunButton buttonPrefab;
    [SerializeField] private Enemy enemy;

    void Start()
    {
        foreach (GunStats gun in guns)
        {
            GunButton button = Instantiate(buttonPrefab, buttonsParent);
            button.Setup(gun, enemy);
        }
    }

}
