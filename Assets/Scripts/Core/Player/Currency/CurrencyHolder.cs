namespace Core.Player.Currency
{
    using System;
    using System.Collections.Generic;

    public class CurrencyHolder
    {
        // Fired whenever a currency value changes: (type, newValue, delta)
        public event Action<CurrencyType, int, int> OnCurrencyChanged;

        private readonly Dictionary<CurrencyType, int> _values = new Dictionary<CurrencyType, int>();

        public CurrencyHolder()
        {
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            {
                _values[type] = 0;
            }
        }

        public int Get(CurrencyType type)
        {
            return _values[type];
        }

        public void Set(CurrencyType type, int newValue)
        {
            int oldValue = Get(type);
            if (oldValue == newValue) return;
            _values[type] = newValue;
            OnCurrencyChanged?.Invoke(type, newValue, newValue - oldValue);
        }

        public int Increment(CurrencyType type, int amount)
        {
            if (amount == 0) return Get(type);
            int oldValue = Get(type);
            int newValue = oldValue + amount;
            _values[type] = newValue;
            OnCurrencyChanged?.Invoke(type, newValue, amount);
            return newValue;
        }

        // Try spend (optional convenience). Returns true if successful.
        public bool TrySpend(CurrencyType type, int amount)
        {
            if (amount <= 0) return true; // nothing to spend
            int current = Get(type);
            if (current < amount) return false;
            Set(type, current - amount);
            return true;
        }
    }
}