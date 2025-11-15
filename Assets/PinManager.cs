using TMPro;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    [SerializeField] private BowlingPin[] pins;
    [SerializeField] private TMP_Text scoreText;
    public string[] names;
    public int knockedDownPins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (BowlingPin pin in pins)
        {
            Debug.Log(pin.name + "  " + pin.transform.position);
        }
        //names = new string[5]
        //{
        //    "AA","BB","CC","DD","EE"
        //};
        //names[0] = "Imie";
        //names[1] = "AAAA";
        //Debug.Log(pins[2].IsKnockedDown);
    }

    // Update is called once per frame
    void Update()
    {
        knockedDownPins = 0;
        // Pêtla Foreach bierze ka¿dy element w kolekcji pins, nazywa go "pin" i robi z nim to co jest w {}
        foreach (BowlingPin pin in pins)
        {
            if (pin.IsKnockedDown)
            {
                knockedDownPins++;
            }
        }
        print(knockedDownPins);
        scoreText.text = knockedDownPins.ToString() + "/" + pins.Length.ToString();
        //scoreText.text = $"{knockedDownPins}/{pins.Length}";
    }
}
