using UnityEngine;

public class Star : MonoBehaviour
{
    public SpriteRenderer StarRenderer;
    public Sprite sprite;

	public void GoldStar()
	{
        // здесь будет проверка на выполнение условий
		StarRenderer.sprite = sprite;
    }
}
