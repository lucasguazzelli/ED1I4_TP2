using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivrosLista
{
    class Livro {

        //Atributos
        private int isbn;
        private string titulo;
        private string author;
        private string editora;
        private List<Exemplar> exemplares;

        //Construtor
        public Livro() {

        }

        //Metodos proprios
        public void adicionarExemplar(Exemplar exemplar) {
            Exemplares.Add(exemplar);
        }

        public int qtdeExemplares() {
            return this.Exemplares.Count;
        }

        public int qtdeDisponiveis() {
            Int32 dispCount = 0;
            foreach (Exemplar exemplar in this.Exemplares) {
                if (exemplar.disponivel()) {
                    dispCount++;
                }
            }
            return dispCount;
        }

        public int qtdeEmprestimos() {
            Int32 totalEmprest =0;
            foreach (Exemplar exemplar in this.Exemplares) {
                totalEmprest += exemplar.qtdeEmprestimos();
            }
            return totalEmprest;
        }

        public double percDisponibilidade() {
            double porcentDisp = 0.00;
            try {
                porcentDisp = (this.qtdeDisponiveis() * 100) / this.qtdeEmprestimos();
            } catch (Exception) {
                return 0.00;
            }
            return porcentDisp;
        }

        public Int32 getListLength()
        {
            return this.exemplares.Count;
        }

        //Getters e Setters

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Author { get => author; set => author = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }
    }
}
