using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GazeInteractionManager : MonoBehaviour
{   
    private XRGazeInteractor _gazeInteractor;
    [SerializeField] private Image _image;
    private float _timeToSelect;
    [SerializeField] float _timer;
    //private bool _isHoveringObject;
    private IXRHoverInteractable _currentInteractable;
    private XRSimpleInteractable interactableObject;
    private XRGazeInteractor interactorObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _gazeInteractor = GetComponent<XRGazeInteractor>();
        _timeToSelect = _gazeInteractor.hoverTimeToSelect;
        
        //Debug.Log(_timeToSelect);
        
        _image.color = Color.white;
    }

    private void OnEnable()
    {
        _gazeInteractor.hoverEntered.AddListener(OnHoverEntered);
        _gazeInteractor.hoverExited.AddListener(OnHoverExited);
        
    }

   

    private void OnDisable()
    {
        _gazeInteractor.hoverEntered.RemoveListener(OnHoverEntered);
        _gazeInteractor.hoverExited.RemoveListener(OnHoverExited);
       
    
    }
    private void OnHoverExited(HoverExitEventArgs arg0)
    {
        //Debug.Log("Hover Exited");
        _currentInteractable = null;
        _timer = 0;
        _image.fillAmount = 0;
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
       
        
        //Debug.Log("Hover Entered");
        _currentInteractable = arg0.interactableObject; // stock variable l'élément interragit regarde
        
        _timer = 0;
        _image.fillAmount = 0;
        

    }

    private void Update()
    {
        if (_currentInteractable == null) return;
        
            _timer += Time.deltaTime;
            _timer = Mathf.Clamp(_timer, 0, _timeToSelect);//evite valeur partir en cacahuète
            var progress = _timer / _timeToSelect;
            var progressColor = Color.Lerp(Color.white, Color.green, progress);
            _image.fillAmount = progress;
            _image.color = progressColor;
        //
        // if (_timer >= _timeToSelect)
        // {
        //     if (_currentInteractable != null)
        //     {
        //         _currentInteractable.transform.GetComponent<XRSimpleInteractable>().selectEntered.Invoke
        //             (new SelectEnterEventArgs
        //             {
        //                 interactableObject=_currentInteractable.transform.GetComponent<XRSimpleInteractable>(),
        //                 interactorObject = _gazeInteractor
        //                 
        //             });
        //         _currentInteractable = null; //force déclenchement invoke
        //
        //
        //     }//select interactable et fonction bourrin
        // }
        
        
    }
}


