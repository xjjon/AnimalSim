using UnityEngine;
using UnityEngine.UIElements;
using Core.Player.Currency;
using Core.State;
using DG.Tweening;

namespace Core.UI
{
    public class CurrencyDisplayUI : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;

        private Label _currencyValueLabel;
        private CurrencyHolder _currencyHolder;
        private Tween _popTween;

        private void Start()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            if (_uiDocument == null)
            {
                Debug.LogError("UIDocument not found on CurrencyDisplayUI");
                return;
            }

            var root = _uiDocument.rootVisualElement;
            _currencyValueLabel = root.Q<Label>("currency-value");

            if (_currencyValueLabel == null)
            {
                Debug.LogError("Currency value label not found in UI Document");
                return;
            }

            Initialize(GameManager.Instance.PlayerCurrency);
        }

        private void Initialize(CurrencyHolder holder)
        {
            if (_currencyHolder != null)
            {
                _currencyHolder.OnCurrencyChanged -= OnCurrencyChanged;
            }

            _currencyHolder = holder;

            if (_currencyHolder != null)
            {
                _currencyHolder.OnCurrencyChanged += OnCurrencyChanged;
                UpdateDisplay(CurrencyType.Mana, _currencyHolder.Get(CurrencyType.Mana));

                _popTween = DOTween.Sequence()
                    .Append(DOTween.To(() => _currencyValueLabel.transform.scale, s => _currencyValueLabel.transform.scale = s, new Vector3(1.3f, 1.3f, 1.3f), 0.15f).SetEase(Ease.OutQuad))
                    .Append(DOTween.To(() => _currencyValueLabel.transform.scale, s => _currencyValueLabel.transform.scale = s, Vector3.one, 0.15f).SetEase(Ease.InQuad))
                    .SetAutoKill(false)
                    .Pause();
            }
        }

        private void OnCurrencyChanged(CurrencyType type, int newValue, int delta)
        {
            UpdateDisplay(type, newValue);
        }

        private void UpdateDisplay(CurrencyType type, int newValue)
        {
            if (_currencyValueLabel != null && type == CurrencyType.Mana)
            {
                _currencyValueLabel.text = newValue.ToString();

                _popTween?.Restart();
            }
        }

        private void OnDestroy()
        {
            if (_currencyHolder != null)
            {
                _currencyHolder.OnCurrencyChanged -= OnCurrencyChanged;
            }
            _popTween?.Kill();
        }
    }
}