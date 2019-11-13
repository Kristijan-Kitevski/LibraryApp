using LibraryApp.Models.Catalog;
using LibraryDataAcses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class CatalogControler : Controller
    {
        private ILibraryAsset _asset;
        public CatalogControler(ILibraryAsset asset)
        {
            _asset = asset;
        }
    
        public IActionResult Index()
        {
            var assetsModels = _asset.GetAll();

            var listingResult = assetsModels
                    .Select(result => new AssetIndexListingModel
                    {
                        Id = result.Id,
                        ImgUrl = result.ImgUrl,
                        AutorOrDirector = _asset.GetAuthorOrDirector(result.Id),
                        DewyCallNumber = _asset.GetDeweyIndex(result.Id),
                        Title = result.Title,
                        Type = _asset.GetType(result.Id)

                    });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);

           
        }
    }
}
