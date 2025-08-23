using Core.Player.Currency;
using Util;

namespace Core.State
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public CurrencyHolder PlayerCurrency { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            PlayerCurrency = new CurrencyHolder();
            PlayerCurrency.Set(CurrencyType.Mana, 10);
        }
    }
}