using System;
using Achievements.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements.Scripts.UI
{
    public class DisplayPlayerCoins : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _image.sprite = Player.Instance.coinsIcon;
        }

        private void Update()
        {
            _text.SetText(Player.Instance.coins.ToString());
        }
    }
}