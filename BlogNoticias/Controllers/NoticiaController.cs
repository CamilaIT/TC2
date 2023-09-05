using BlogNoticias.Interface;
using BlogNoticias.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogNoticias.Controllers {
    [Authorize]
    [Route("api/noticia")]
    [ApiController]
    public class NoticiaController : ControllerBase {
        private readonly INoticias _INoticia;
        private static int countId = 0;
        private static DateTime data = DateTime.Now;

        public NoticiaController(INoticias INoticia) {
            _INoticia = INoticia;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticia>>> Get() {
            return await Task.FromResult(_INoticia.GetNoticia());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticia>> Get(int id) {
            var noticias = await Task.FromResult(_INoticia.GetNoticia(id));
            if (noticias == null) {
                return NotFound();
            }
            return noticias;
        }

        
        [HttpPost]
        public async Task<ActionResult<Noticia>> Post(Noticia noticia) {
            noticia.Id = countId++;
            noticia.DataPublicacao = data;
            _INoticia.AddNoticia(noticia);
            return await Task.FromResult(noticia);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Noticia>> Put(int id, Noticia noticia) {
            if (id != noticia.Id) {
                return BadRequest();
            }
            try {
                _INoticia.UpdateNoticia(noticia);
            } catch (DbUpdateConcurrencyException) {
                if (!NoticiaExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return await Task.FromResult(noticia);
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Noticia>> Delete(int id) {
            var noticia = _INoticia.DeleteNoticia(id);
            return await Task.FromResult(noticia);
        }

        private bool NoticiaExists(int id) {
            return _INoticia.CheckNoticia(id);
        }
    }
}
