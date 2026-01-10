using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;

    public void Setup(GunStats gunStats, Enemy enemy)
    {
        text.text = gunStats.Name;
        image.sprite = gunStats.Icon;
        button.onClick.AddListener(() => enemy.ShootWithGun(gunStats));
    }
}
