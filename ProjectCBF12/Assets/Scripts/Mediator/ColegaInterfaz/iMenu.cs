using UnityEngine;

namespace Assets.Scripts.Mediator{
public abstract class IMenu : MonoBehaviour
{ 
    protected MenuMediator _mediator;

    public void Configure(MenuMediator menuMediator){
            _mediator = menuMediator;
    }
    public abstract void Hide();
    public abstract void Show();
}
}