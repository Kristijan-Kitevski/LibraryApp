using LibraryDataAcses;
using LibraryDataAcses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{

    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryDbContext _context;

        public LibraryAssetService( LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location);
        }

        
        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id==id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.Id==id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(b => b.Id == id))
            {
                return _context.Books.FirstOrDefault(b => b.Id == id).DeweyIndex;
            }
            else
            {
                return string.Empty;
            }

        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(b => b.Id == id))
            {
                return _context.Books.FirstOrDefault(b => b.Id == id).ISBN;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            var Book = _context.LibraryAssets
                .OfType<Book>()
                .Where(b => b.Id == id);
            return Book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets
                            .OfType<Book>()
                                .Where(b => b.Id == id)
                                    .Any();

            var isVideo = _context.LibraryAssets
                           .OfType<Video>()
                               .Where(v => v.Id == id)
                                    .Any();

            return isBook ?
                         _context.Books.FirstOrDefault(b => b.Id == id).Author :
             
                         _context.Videos.FirstOrDefault(v => v.Id == id).Director;
        }

    }
}
