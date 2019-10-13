using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivrosLista {
    class Livros {
        private List<Livro> acervo;

        internal List<Livro> Acervo { get => acervo; set => acervo = value; }

        //Construtor
        public Livros() {
            acervo = new List<Livro>();
        }

        //Metodos
        public void adicionar(Livro livro) {
            acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro) {
            foreach(Livro livroDoAcervo in this.acervo) {
                if (livroDoAcervo.Isbn == livro.Isbn) {
                    return livroDoAcervo;
                }
            }
            return null;
        }

        public Int32 getListLength() {
            return this.acervo.Count;
        }
    }
}
