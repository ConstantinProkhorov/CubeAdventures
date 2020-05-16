using UnityEngine;
/// <summary>
/// PopUps created usin Factory Method.
/// IPopUpFactory used to create GameObject containing IPopUp
/// </summary>
public interface IPopUpFactory
{
    /// <summary>
    /// Places PopUp GameObject in the scene with IPopUpComponent. 
    /// </summary>
    /// <param name="position">Based on provided Vector PopUp position will be calculated.</param>
    /// <returns>IPopUp of placed GameObject.</returns>
    IPopUp CreatePopUp(Vector3 position);
}
/// <summary>
/// PopUp created by IPopUpFactory.
/// </summary>
public interface IPopUp
{
    /// <summary>
    /// PopUps show numberToShow given in parameter.
    /// If method isn't called, PopUp will show nothing.
    /// <param name="numberToShow">Nubmer that popUp will show.</param>
    /// </summary>
    void SetOutput(int numberToShow);
}
