using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProj.Models.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<MovieModel> Movie { get; set; }

        public MovieModel MovieModel { get; set; }
    }
}
