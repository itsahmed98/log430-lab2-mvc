using Microsoft.AspNetCore.Mvc;
using MagasinCentral.Services;
using MagasinCentral.Data;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Controllers;

/// <summary>
/// Controller pour gérer les ventes.
/// </summary>
public class VenteController : Controller
{
    private readonly IVenteService _venteService;
    private readonly IProduitService _produitService;
    private readonly MagasinDbContext _contexte;

    /// <summary>
    /// Constructeur pour initialiser les services nécessaires à la gestion des ventes.
    /// </summary>
    /// <param name="venteService"></param>
    /// <param name="produitService"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public VenteController(IVenteService venteService, IProduitService produitService, MagasinDbContext contexte)
    {
        _venteService = venteService ?? throw new ArgumentNullException(nameof(venteService));
        _produitService = produitService ?? throw new ArgumentNullException(nameof(produitService));
        _contexte = contexte ?? throw new ArgumentNullException(nameof(contexte));
    }


    /// <summary>
    /// Affiche le formulaire pour enregistrer une vente dans un magasin spécifique.
    /// </summary>
    /// <param name="magasinId"></param>
    public async Task<IActionResult> Enregistrer(int? magasinId)
    {
        var magasins = await _contexte.Magasins
            .AsNoTracking()
            .ToListAsync();

        ViewData["Magasins"] = magasins;
        ViewData["MagasinId"] = magasinId ?? 0;

        var produits = await _produitService.GetAllProduitsAsync();
        return View(produits);
    }


    /// <summary>
    /// Enregistre une vente pour un magasin donné avec les produits et quantités spécifiés.
    /// </summary>
    /// <param name="magasinId"></param>
    /// <param name="produitId"></param>
    /// <param name="quantite"></param>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enregistrer(int magasinId, List<int> produitId, List<int> quantite)
    {
        var lignes = produitId.Zip(quantite, (id, q) => (id, q)).ToList();
        try
        {
            await _venteService.EnregistrerVenteAsync(magasinId, lignes);
            TempData["Succès"] = "Vente enregistrée";
            return RedirectToAction("Index", "Rapport");
        }
        catch (Exception ex)
        {
            TempData["Erreur"] = ex.Message;
            return RedirectToAction(nameof(Enregistrer), new { magasinId });
        }
    }

    /// <summary>
    /// Annule une vente existante et restitue le stock au magasin.
    /// </summary>
    /// <param name="venteId"></param>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Retour(int venteId)
    {
        try
        {
            await _venteService.AnnulerVenteAsync(venteId);
            TempData["Succès"] = "Vente annulée et stock restitué.";
        }
        catch (Exception ex)
        {
            TempData["Erreur"] = ex.Message;
        }
        return RedirectToAction("Liste", "Vente");
    }

    /// <summary>
    /// Affiche la liste de toutes les ventes enregistrées, incluant les informations sur le magasin et les produits.
    /// </summary>
    public async Task<IActionResult> Liste()
    {
        var ventes = await _venteService.GetVentesAsync();
        return View("ListeVentes", ventes);
    }


}
