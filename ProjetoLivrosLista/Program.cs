using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjetoLivrosLista {
    class Program {

        static Int16 opcao;
        static Livros livros;

        static void Main(string[] args) {

            Console.WriteLine("" +
                "-----------------------\n" +
                " Projeto Livros Lista\n" +
                "-----------------------\n"
            );
            Thread.Sleep(1250);
            Program.livros = new Livros();
            while (true) {
                menu();
            }
        }

        static void menu() {
            Console.Clear();
            Console.Write("" +
                "---------------------------------\n" +
                "              Menu\n" +
                "---------------------------------\n" +
                " 0 . Sair\n" +
                " 1 . Adicionar Livro\n" +
                " 2 . Pesquisar Livro (sintetico)\n" +
                " 3 . Pesquisar Livro (analitico)\n" +
                " 4 . Adicionar Exemplar\n" +
                " 5 . Registrar emprestimo\n" +
                " 6 . Registrar devolução\n" +
                " Digite uma opção: ");
            try {
                opcao = Convert.ToInt16(Console.ReadLine());
            } catch (Exception) {
                AddExcecao(" ERRO: Parametro incorreto!", 1500);
            }

            switch (opcao) {
                case 1:
                    Livro novoLivro = new Livro();
                    Console.Write("" +
                        "---------------------------------\n" +
                        "         Adicionar Livro\n" +
                        "---------------------------------\n" +
                        " Digite o titulo: "
                    );
                    novoLivro.Titulo = Console.ReadLine();
                    Console.Write(" Digite o autor: ");
                    novoLivro.Author = Console.ReadLine();
                    Console.Write(" Digite a editora: ");
                    novoLivro.Editora = Console.ReadLine();
                    novoLivro.Isbn = Program.livros.getListLength();
                    novoLivro.Exemplares = new List<Exemplar>();
                    Program.livros.adicionar(novoLivro);
                    Console.WriteLine(" Livro adicionado com sucesso!\n Identificador: " + (livros.getListLength()-1));
                    Thread.Sleep(1750);
                    break;

                case 2:
                    Console.Write("" +
                        "---------------------------------\n" +
                        "   Pesquisar Livro (sintetico)\n" +
                        "---------------------------------\n" +
                        " Digite o identificador do livro: "
                    );
                    PesquisarLivro();
                    Console.WriteLine(" Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Write("" +
                        "---------------------------------\n" +
                        "   Pesquisar Livro (analítico)\n" +
                        "---------------------------------\n" +
                        " Digite o identificador do livro: "
                    );
                    Livro livro = new Livro();
                    livro = PesquisarLivro();
                    foreach (Exemplar exemplar in livro.Exemplares) {
                        Console.WriteLine(" Exemplar " + exemplar.Tombo + ":");
                        foreach (Emprestimo emprestimo in exemplar.Emprestimo) {
                            Console.WriteLine("     Emprestimo:");
                            Console.WriteLine("     Data de Emprestimo: " + emprestimo.DtEmprestimo);
                            if ( emprestimo.DtDevolucao != new DateTime(1, 1, 1, 0, 0, 0 )) {
                                Console.WriteLine("     Data de Devolução: " + emprestimo.DtDevolucao);
                            } else {
                                Console.WriteLine("     Data de Devolução: Pendente.");
                            }
                        }
                    }                    
                    Console.WriteLine(" Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Write("" +
                        "---------------------------------\n" +
                        "       Adicionar Exemplar\n" +
                        "---------------------------------\n" +
                        " Digite o identificador do livro: "
                    );
                    Livro livroComNovoExemplar = new Livro();
                    try {
                        livroComNovoExemplar.Isbn = Convert.ToInt32(Console.ReadLine());
                        livros.Acervo[livroComNovoExemplar.Isbn] = livros.pesquisar(livroComNovoExemplar);
                        Exemplar novoExemplar = new Exemplar(livros.Acervo[livroComNovoExemplar.Isbn].getListLength());
                        livros.Acervo[livroComNovoExemplar.Isbn].adicionarExemplar(novoExemplar);
                        Console.WriteLine(" FEITO: Nova quantidade de exemplares: " + livros.Acervo[livroComNovoExemplar.Isbn].qtdeExemplares());
                    } catch (Exception) {
                        AddExcecao(" ERRO: Parametro incorreto!",1500);
                        break;
                    }
                    Thread.Sleep(1250);
                    break;

                case 5:
                    Console.Write("" +
                        "---------------------------------\n" +
                        "       Registrar Emprestimo\n" +
                        "---------------------------------\n"
                    );
                    Int32 livroId = 0, tomboID = 0;
                    try {
                        Console.Write(" Digite o identificador do livro: ");
                        livroId = Convert.ToInt32(Console.ReadLine());
                        Console.Write(" Digite o tombo do exemplar: ");
                        tomboID = Convert.ToInt32(Console.ReadLine());
                    } catch (Exception) {
                        AddExcecao(" ERRO: Parametro incorreto!",2500);
                    }
                    foreach (Livro livroNovoEmprest in livros.Acervo) {
                        if (livroNovoEmprest.Isbn == livroId) {
                            foreach (Emprestimo emprest in livroNovoEmprest.Exemplares[tomboID].Emprestimo) {
                                if (emprest.DtDevolucao == new DateTime(1, 1, 1, 0, 0, 0)) {
                                    AddExcecao(" AVISO: Este exemplar não se encontra disponível pois já foi emprestado e ainda não foi devolvido.", 2500);
                                    break;
                                }
                            }
                            if (livroNovoEmprest.Exemplares[tomboID].Tombo == livroNovoEmprest.Exemplares[tomboID].Emprestimo.Count - 1 || livroNovoEmprest.Exemplares[tomboID].Emprestimo.Count == 0) {
                                livroNovoEmprest.Exemplares[tomboID].Emprestimo.Add(new Emprestimo(DateTime.Now));
                                Console.WriteLine(" FEITO: Novo emprestimo realizado as: " + livroNovoEmprest.Exemplares[tomboID].Emprestimo[livroNovoEmprest.Exemplares[tomboID].Emprestimo.Count-1].DtEmprestimo);
                            }
                        }
                    }
                    Thread.Sleep(2500);
                    break;

                case 6:
                    Console.Write("" +
                        "---------------------------------\n" +
                        "       Registrar Devoluçao\n" +
                        "---------------------------------\n"
                    );
                    Int32 livroId2 = 0;
                    try {
                        Console.Write(" Digite o identificador do livro: ");
                        livroId2 = Convert.ToInt32(Console.ReadLine());
                    } catch (Exception) {
                        AddExcecao(" Erro: Parametro incorreto!",2500);
                        break;
                    }
                    foreach (Livro livroDevolver in livros.Acervo) {
                        if (livroDevolver.Isbn == livroId2) {
                            foreach (Exemplar exemplar in livroDevolver.Exemplares) {
                                if (exemplar.Tombo == exemplar.Emprestimo.Count-1) {
                                    exemplar.devolver();
                                    Console.WriteLine(" Emprestimo Retornado as: " + exemplar.Emprestimo[exemplar.Emprestimo.Count - 1].DtDevolucao);
                                }
                            }
                        }
                    }
                    Thread.Sleep(2500);
                    break;

                default:
                    System.Environment.Exit(0);
                    break;
            }
        }

        static Livro PesquisarLivro() {
            Livro livroPesquisado = new Livro();
            try {
                livroPesquisado.Isbn = Convert.ToInt32(Console.ReadLine());
            } catch (Exception) {
                System.Environment.Exit(2);
            }
            livroPesquisado = Program.livros.pesquisar(livroPesquisado);
            Console.Write("" +
                "---------------------------------\n" +
                "            Resultado\n" +
                "---------------------------------\n"
            );
            if (livroPesquisado == null) {
                AddExcecao(" Nenhum resultado encontrado!", 2500);
            } else {
                Console.WriteLine("               Titulo: " + livroPesquisado.Titulo);
                Console.WriteLine("                Autor: " + livroPesquisado.Author);
                Console.WriteLine("              Editora: " + livroPesquisado.Editora);
                Console.WriteLine("     total exemplares: " + livroPesquisado.qtdeExemplares());
                Console.WriteLine("     exemplares disp.: " + livroPesquisado.qtdeDisponiveis());
                Console.WriteLine("   emprestimos totais: " + livroPesquisado.qtdeEmprestimos());
                Console.WriteLine(" % de disponibilidade: {0:0.00}%",livroPesquisado.percDisponibilidade());
            }
            return livroPesquisado;
        }

        public static void AddExcecao(string errorMsg, int waitingTime) {
            Console.WriteLine(errorMsg);
            Thread.Sleep(waitingTime);
            menu();
        }
    }
}
