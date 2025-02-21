using System.Collections.Generic;
using GameScene.Entity;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

namespace GameScene.GameManager
{
    public class GameManagement : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _entitiyPrefabs;

        [SerializeField]
        private Transform[] _transformsSpawnEntities;

        private List<EntityUI> _entities = new List<EntityUI>();

        [SerializeField]
        private GameObject _endPanel;

        [SerializeField]
        private TMP_Text _textInEndPanel;

        private async void Start()
        {
            CreateEntitys();
        }

        private void CreateEntitys()
        {
            for (int i = 0; i < _transformsSpawnEntities.Length; i++)
            {
                _entities.Add(Instantiate(_entitiyPrefabs[Random.Range(0, _entitiyPrefabs.Length)], 
                    _transformsSpawnEntities[i].position, 
                    Quaternion.identity, 
                    _transformsSpawnEntities[i]).GetComponent<EntityUI>());
            }
        }

        public void ActivateEndPanel(string nameEntity)
        {
            _endPanel.SetActive(true);
            _textInEndPanel.text = $"������� ����� � ����� {nameEntity}! ������ ������� ��� ���?";
        }

        public void ReloadLevel()
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i] != null)
                {
                    _entities[i].DestroyThisObject();
                }
            }

            _endPanel.SetActive(false);
            CreateEntitys();
        }
    }
}