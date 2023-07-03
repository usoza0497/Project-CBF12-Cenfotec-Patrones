using AbstractFactory;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    private LevelFactory levelFactory = new LevelFactory();

   [SerializeField]
   private RectTransform buttonContainer;

   [SerializeField]
   private LevelButton buttonPrefab;

   [SerializeField]
   private float buttonSpacing = 10f;

   [SerializeField]
   float yOffset = 40f;
   
   private void Start() 
   {
        float buttonHeight = buttonPrefab.GetComponent<RectTransform>().rect.height;
        

        foreach(string name in levelFactory.GetLevelNames())
        {
            var button = Instantiate(buttonPrefab, buttonContainer);
            button.gameObject.name = name + "Button";
            button.SetLevelName(name);
            button.SetLevel(levelFactory.GetLevel(name));
            button.gameObject.SetActive(true);

            RectTransform buttonTransform = button.GetComponent<RectTransform>();
            buttonTransform.anchoredPosition = new Vector2(0f, yOffset);
            yOffset -= buttonHeight + buttonSpacing;
        }
   }
}

