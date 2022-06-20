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

                // extrai a lista de gêneros possíveis da lista de filmes
                // aqui, só cria a query, mas ainda não a executa
                IQueryable<string> genreQuery = from m in _context.Movie
                                                orderby m.Genre
                                                select m.Genre;

                var movies = from m in _context.Movie
                             select m;

                // se a string de busca (definida no bind property)
                // estiver preenchida
                if (!string.IsNullOrEmpty(SearchString))
                {
                    // cria uma LINQ que filtrará os filmes por título
                    movies = movies.Where(s => s.Title.Contains(SearchString));
                }

                // se a string de gênero (definida no bind property)
                // estiver preenchida
                if (!string.IsNullOrEmpty(MovieGenre))
                {
                    // cria uma LINQ que filtrará os filmes por gênero. Pode
                    // ser que este filtro se encadeie com o anterior, caso
                    // ele tenha sido acionado
                    movies = movies.Where(x => x.Genre == MovieGenre);
                }

                // cria a lista de gêneros (aqui, é a execução da query criada
                // no início deste método
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

                // a query só é executada neste ponto
                Movie = await movies.ToListAsync();

            }
        }
    }
}
