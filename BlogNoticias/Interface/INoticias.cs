using BlogNoticias.Models;

namespace BlogNoticias.Interface {
    public interface INoticias {
        public List<Noticia> GetNoticia();
        public Noticia GetNoticia(int id);
        public void AddNoticia(Noticia noticia);
        public void UpdateNoticia(Noticia noticia); 
        public Noticia DeleteNoticia(int id);
        public bool CheckNoticia(int id);
    }
}
