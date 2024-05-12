using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public class EquipmentManager : MonoBehaviour
    {
        [SerializeField] private StablePlayerController _player;
        [SerializeField] private Wallet _wallet;

        [Header("Equipment Related Objects")]
        [SerializeField] private CommonEquipmentInfo _equipmentInfo;
        [SerializeField] private EquipmentItemGenerator _equipmentGenerator;
        [SerializeField] private EquipmentInventory _equipmentInventory;

        [SerializeField] private GameObject _popUp;
        private EquipmentDigger _equipmentDigger;

        private bool _IsPopUpOpened;

        private void Start()
        {
            _equipmentDigger = _popUp.GetComponentInChildren<EquipmentDigger>();
            _equipmentGenerator.Initialize(_equipmentInfo);
            _equipmentDigger.Initialize(_equipmentGenerator, _equipmentInventory, _equipmentInfo, _wallet);
            _equipmentInventory.Initialize(_equipmentInfo);

            _player.OnCharacterClick += OpenNewPopUp;
            _equipmentDigger.OnChoiceMade += ClosePopUp;
        }

        private void OnDisable()
        {
            _player.OnCharacterClick -= OpenNewPopUp;
            _equipmentDigger.OnChoiceMade -= ClosePopUp;
        }

        public void OpenNewPopUp()
        {
            if (_IsPopUpOpened)
                return;
            //TO-DO Make Animations
            _IsPopUpOpened = true;
            _popUp.SetActive(true);
            _equipmentDigger.Dig();
        }

        private void ClosePopUp()
        {
            _IsPopUpOpened = false;
            _popUp.SetActive(false);
        }
    }
}

