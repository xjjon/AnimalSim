using UnityEngine;
using UnityEngine.UIElements;
using Core.Player.Currency;

namespace Core.UI
{
    public class CurrencyDisplayUI : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;
        
        private Label currencyValueLabel;
        private CurrencyHolder currencyHolder;

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
            currencyValueLabel = root.Q<Label>("currency-value");
            
            if (currencyValueLabel == null)
            {
                Debug.LogError("Currency value label not found in UI Document");
                return;
            }
        }
        
        public void Initialize(CurrencyHolder holder)
        {
            if (currencyHolder != null)
            {
                currencyHolder.OnCurrencyChanged -= OnCurrencyChanged;
            }
            
            currencyHolder = holder;
            
            if (currencyHolder != null)
            {
                currencyHolder.OnCurrencyChanged += OnCurrencyChanged;
                UpdateDisplay(CurrencyType.Mana, currencyHolder.Get(CurrencyType.Mana), 0);
            }
        }
        
        private void OnCurrencyChanged(CurrencyType type, int newValue, int delta)
        {
            UpdateDisplay(type, newValue, delta);
        }
        
        private void UpdateDisplay(CurrencyType type, int newValue, int delta)
        {
            if (currencyValueLabel != null && type == CurrencyType.Mana)
            {
                currencyValueLabel.text = newValue.ToString();
            }
        }
        
        private void OnDestroy()
        {
            if (currencyHolder != null)
            {
                currencyHolder.OnCurrencyChanged -= OnCurrencyChanged;
            }
        }
    }
}