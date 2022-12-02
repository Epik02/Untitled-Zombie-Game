using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=dUCcZrPhwSo
// https://www.youtube.com/watch?v=DBBbpbIRoIc

//public class ActionRebind : MonoBehaviour
//{
//    //serialize fields cuz pog

//    //InputActionReference
//    [SerializeField] private InputActionReference shootAction = null;
//    //Storage for our action map
//    [SerializeField] private PlayerAction playerAction = null;

//    [SerializeField] private Button shootRebind;

//    //clean memory
//    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

//    //This is to load and create buttons
//    private void Awake()
//    {
//        //shootRebind.onClick.AddListener(() => StartRebinding());
//        //Debug.Log("Rebind On");

//        string rebinds = PlayerPrefs.GetString("rebinds", string.Empty);

//        if (string.IsNullOrEmpty(rebinds)) { return; }

//        playerAction.playerInput.actions.LoadBindingOverridesFromJson(rebinds);

        

        
//    }
//    // This is the save
//    public void SaveKey()
//    {
//        string rebinds = playerAction.playerInput.actions.SaveBindingOverridesAsJson();

//        PlayerPrefs.SetString("rebinds", rebinds);
//    }

//    public void StartRebinding()
//    { 
//        //rebindingOperation = shootAction.action.PerformInteractiveRebinding().Start();
//        //Debug.Log("Did Rebind");
//    }
    
    
    
//}
