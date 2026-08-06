using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private float hitCount = 0;

    public void ButtonShot()
    {
        Debug.Log("Hit!");
        hitCount++;
        if (hitCount > 10) hitCount = 0;
        Button button = GetComponentInParent<Button>();

        var colors = button.colors;
        colors.normalColor = new Color(255f, 255f, 255f, hitCount/10);; 
        button.colors = colors;

    }

    
}
