using UnityEngine;

public class SelectForm : MonoBehaviour
{
    public Player_Assembler _Player_Assembler;
    string FigureName;
    RaycastHit hit; // интересно, здесь происходит boxing? если так, то было бы более оптимальным объявить эту переменную прямо в Update()?

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("FormForSelection"))
                {
                    FigureName = hit.collider.gameObject.name;
                    Destroy(CraftSceneController.player);
                    CraftSceneController.player = _Player_Assembler.Player_Creator(new Vector3(0, 2, 2), FigureName, 2);
                    SceneController.LastForm = FigureName;
                } 
            }
        }
    }
}
