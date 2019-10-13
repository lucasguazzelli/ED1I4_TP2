using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivrosLista {
    class Exemplar {

        //Atributos
        private int tombo;
        private List<Emprestimo> emprestimo;

        //Construtor
        public Exemplar() 
        {
            emprestimo = new List<Emprestimo>();
        }
        public Exemplar(Int32 t) {
            tombo = t;
            emprestimo = new List<Emprestimo>();
        }

        //Metodos
        public bool emprestar() {
            emprestimo.Add(new Emprestimo(DateTime.Now));
            return true;
        }

        public bool devolver() {
            try {
                this.Emprestimo[this.Emprestimo.Count - 1].DtDevolucao = DateTime.Now;
            } catch (Exception) {
                return false;
            }
            return true;
        }

        public bool disponivel() {
            if (!(emprestimo.Count <= 0)) {
                foreach (Emprestimo emp in emprestimo) {
                    if (emp.DtDevolucao != new DateTime(0001, 01, 01, 00, 00, 00)) {
                        return true;
                    }
                }
            }
            return false;
        }

        public int qtdeEmprestimos() {
            return this.emprestimo.Count;
        }

        //Getters e Setters

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimo { get => emprestimo; set => emprestimo = value; }
    }
}
