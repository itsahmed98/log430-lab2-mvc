using MagasinCentral.ViewModels;
using System.Threading.Tasks;

namespace MagasinCentral.Services
{
    /// <summary>
    ///     Définit les opérations pour UC3 : génération des données du tableau de bord.
    /// </summary>
    public interface IPerformancesService
    {
        /// <summary>
        /// Récupère les données du tableau de bord pour les performances.
        /// </summary>
        Task<PerformancesViewModel> GetPerformances();
    }
}
