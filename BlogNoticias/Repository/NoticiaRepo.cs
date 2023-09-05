using BlogNoticias.Interface;
using BlogNoticias.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNoticias.Repository
    {

    public class NoticiaRepo : INoticias {

        readonly DatabaseContext _dbContext = new();

        public NoticiaRepo(DatabaseContext dbContext) {
            _dbContext = dbContext;
        }

        public List<Noticia> GetNoticia() {
            try 
            {
                return _dbContext.Noticias.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Noticia GetNoticia(int id) {
            try {
                Noticia? noticia = _dbContext.Noticias.Find(id);
                if (noticia != null) {
                    return noticia;
                } else {
                    throw new ArgumentNullException();
                }
            } catch {
                throw;
            }
        }

        public void AddNoticia(Noticia noticia) {
            try {
                _dbContext.Noticias.Add(noticia);
                _dbContext.SaveChanges();
            } catch {
                throw;
            }
        }

        public void UpdateNoticia(Noticia noticia) {
            try {
                _dbContext.Entry(noticia).State = EntityState.Modified;
                _dbContext.SaveChanges();
            } catch {
                throw;
            }
        }

        public Noticia DeleteNoticia(int id) {
            try {
                Noticia? noticia = _dbContext.Noticias.Find(id);

                if (noticia != null) {
                    _dbContext.Noticias.Remove(noticia);
                    _dbContext.SaveChanges();
                    return noticia;
                } else {
                    throw new ArgumentNullException();
                }
            } catch {
                throw;
            }
        }

        public bool CheckNoticia(int id) {
            return _dbContext.Noticias.Any(e => e.Id == id);
        }  
    }
}
