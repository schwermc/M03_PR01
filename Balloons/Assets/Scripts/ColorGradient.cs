using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    [SerializeField] Color[] colors;

    private Gradient gradient;
    private GradientColorKey[] gradients;
    private GradientAlphaKey[] alphas;

    // Start is called before the first frame update
    void Start()
    {
        gradient = new Gradient();
        gradients = new GradientColorKey[colors.Length];
        alphas = new GradientAlphaKey[colors.Length];

        int i = 0;
        gradients[i] = new GradientColorKey(colors[i], 0.0f);
        alphas[i] = new GradientAlphaKey(1.0f, 0.0f);
        for (i = 1; i < colors.Length; i++)
        {
            gradients[i] = new GradientColorKey(colors[i], 1.0f);
            alphas[i] = new GradientAlphaKey(0.0f, 1.0f);
        }

        gradient.SetKeys(gradients, alphas);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Renderer>().material.color = gradient.Evaluate(1);
    }
}
