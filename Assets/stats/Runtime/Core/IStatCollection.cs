using SeawispHunter.RolePlay.Attributes;

namespace Esuriru.Stats
{
    public interface IStatCollection<T>
    {
        bool TryGetStat(StatType statType, 
            out IModifiableValue<T> modifiableValue);

        IModifiableValue<T> GetStat(StatType statType);
    }
}