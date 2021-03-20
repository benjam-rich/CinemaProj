using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProj.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(MovieModel movie)
        {
            CartLine line = Lines
                .Where(p => p.Movie.MovieId == movie.MovieId)
                .FirstOrDefault();
        }

        public virtual void RemoveLine(MovieModel m) =>
            Lines.RemoveAll(x => x.Movie.MovieId == m.MovieId);

        public virtual void Clear() => Lines.Clear();


        public class CartLine
        {
            public int CartLineID { get; set; }
            public MovieModel Movie { get; set; }
        }
    }
}
