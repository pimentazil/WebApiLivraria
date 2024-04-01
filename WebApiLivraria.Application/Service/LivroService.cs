using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLivraria.Application.Model;
using WebApiLivraria.Repository;
using WebApiLivraria.Repository.Models;


namespace WebApiLivraria.Application.Service
{
    public class LivroService
    {
        private readonly Context _ctx;

        public LivroService(Context context)
        {
            _ctx = context;
        }

        public bool adicionarLivro(LivroRequest request)
        {
            try
            {
                var livro = new TabLivros()
                {
                    titulo = request.titulo,
                    autor = request.autor,
                    genero = request.genero,
                    preco = request.preco,
                    quantidade = request.quantidade
                };

                _ctx.tabLivros.Add(livro);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<TabLivros> obterLivros()
        {
            try
            {
                List<TabLivros> livro = new List<TabLivros>();
                var livros = _ctx.tabLivros.ToList();
                foreach (var item in livros)
                {

                    livro.Add(new TabLivros
                    {
                        id = item.id,
                        titulo = item.titulo,
                        autor = item.autor,
                        genero = item.genero,
                        preco = item.preco,
                        quantidade = item.quantidade
                    });
                }
                return livro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TabLivros obterLivro(int id)
        {
            try
            {
                return _ctx.tabLivros.FirstOrDefault(x => x.id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deletarLivro(int livroId)
        {
            try
            {
                var livro = _ctx.tabLivros.Find(livroId);

                if (livro != null)
                {
                    _ctx.tabLivros.Remove(livro);
                    _ctx.SaveChanges();
                    return true;
                }

                return false; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool atualizarLivro(int livroId, LivroRequest request)
        {
            try
            {
                var livro = _ctx.tabLivros.Find(livroId);

                if (livro != null)
                {
                    livro.titulo = request.titulo;
                    livro.autor = request.autor;
                    livro.genero = request.genero;
                    livro.preco = request.preco;
                    livro.quantidade = request.quantidade;

                    _ctx.SaveChanges();
                    return true;
                }

                return false; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}