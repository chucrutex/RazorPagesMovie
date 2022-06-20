using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public IndexModel(RazorPagesMovieContext context)

        // construtor
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Movie != null)
            {

                var movies = from m in _context.Movie select m;

                // se a string de busca (definida no bind property)
                // estiver preenchida
                if (!string.IsNullOrEmpty(SearchString))
                {
                    // cria uma LINQ que filtrará os filmes
                    movies = movies.Where(s => s.Title.Contains(SearchString));
                }

                // a query só é executada neste ponto
                Movie = await movies.ToListAsync();

            }
        }
    }
}
