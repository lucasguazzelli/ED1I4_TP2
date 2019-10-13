using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivrosLista {
    class Emprestimo {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        //Construtor
        public Emprestimo(DateTime date) {
            dtEmprestimo = date;
        }

        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }
        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }
    }
}
