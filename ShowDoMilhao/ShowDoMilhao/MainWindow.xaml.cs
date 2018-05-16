using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowDoMilhao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public Jogador Jogador;
        public List<Pergunta> Perguntas;
        public int IDPerguntaAtual;

        public MainWindow()
        {
            Perguntas = new List<Pergunta>();
            InitializeComponent();
            IDPerguntaAtual = 0;

            var pergunta1 = new Pergunta
            {
                Enunciado = "Em 2005, o São Paulo bateu o Corinthians pelo campeonato brasileiro no dia 08/05, qual foi o resultado?",
                Resposta1 = "Corinthians 0 - 3 São Paulo",
                Resposta2 = "Corinthians 1 - 5 São Paulo",
                Resposta3 = "Corinthians 2 - 3 São Paulo",
                Resposta4 = "Corinthians 2 - 5 São Paulo",
                Resposta5 = "Corinthians 0 - 6 São Paulo",
                RespostaCorreta = 2
            };

            var pergunta2 = new Pergunta
            {
                Enunciado = "Qual time rubro negro de Pernambuco ?",
                Resposta1 = "Sport",
                Resposta2 = "Santa Cruz",
                Resposta3 = "Ibis",
                Resposta4 = "Central",
                Resposta5 = "Náutico",
                RespostaCorreta = 1
            };

            var pergunta3 = new Pergunta
            {
                Enunciado = "Quantos o Brasil tem de Copa do Mundo?",
                Resposta1 = "1",
                Resposta2 = "2",
                Resposta3 = "3",
                Resposta4 = "6",
                Resposta5 = "5",
                RespostaCorreta = 4
            };
            var pergunta4 = new Pergunta
            {
                Enunciado = "Qual time foi campeão da UEFA Champions League de 2017?",
                Resposta1 = "Real Madrid",
                Resposta2 = "Liverpool",
                Resposta3 = "Manchester City",
                Resposta4 = "Roma",
                Resposta5 = "Juventos",
                RespostaCorreta = 1
            };
            var pergunta5 = new Pergunta
            {
                Enunciado = "Qual o atual campeão da Copa do Mundo de Futebol?",
                Resposta1 = "Brasil",
                Resposta2 = "Alemanha",
                Resposta3 = "Argentina",
                Resposta4 = "Itália",
                Resposta5 = "Japão",
                RespostaCorreta = 2
            };
            var pergunta6 = new Pergunta
            {
                Enunciado = "Quantas vezes Messi foi eleito o melhor jogador do mundo ?",
                Resposta1 = "1",
                Resposta2 = "2",
                Resposta3 = "3",
                Resposta4 = "4",
                Resposta5 = "5",
                RespostaCorreta = 5
            };
            var pergunta7 = new Pergunta
            {
                Enunciado = "Quantas vezes Cristiano Ronaldo foi eleito o melhor jogador do mundo ?",
                Resposta1 = "5",
                Resposta2 = "4",
                Resposta3 = "3",
                Resposta4 = "2",
                Resposta5 = "1",
                RespostaCorreta = 1
            };
            var pergunta8 = new Pergunta
            {
                Enunciado = "Qual o último time campeão mundial brasileiro?",
                Resposta1 = "Corinthians",
                Resposta2 = "Internacional",
                Resposta3 = "Palmeiras",
                Resposta4 = "Santos",
                Resposta5 = "Flamengo",
                RespostaCorreta = 1
            };
            var pergunta9 = new Pergunta
            {
                Enunciado = "Qual a foi a final da Copa do mundo do Brasil em 2014?",
                Resposta1 = "Brasil x Alemanha",
                Resposta2 = "Argentina x Itália",
                Resposta3 = "Alemanha x Argentina",
                Resposta4 = "Alemanha x Japão",
                Resposta5 = "Croácia x Brasil",
                RespostaCorreta = 3
            };
            var pergunta10 = new Pergunta
            {
                Enunciado = "Qual o jogador com a transferencia mais cara do futebol?",
                Resposta1 = "Neymar",
                Resposta2 = "Messi",
                Resposta3 = "Cristiano Ronaldo",
                Resposta4 = "Gabriel Jesus",
                Resposta5 = "Philippe Coutinho",
                RespostaCorreta = 1
            };

            Perguntas.Add(pergunta1);
            Perguntas.Add(pergunta2);
            Perguntas.Add(pergunta3);
            Perguntas.Add(pergunta4);
            Perguntas.Add(pergunta5);
            Perguntas.Add(pergunta6);
            Perguntas.Add(pergunta7);
            Perguntas.Add(pergunta8);
            Perguntas.Add(pergunta9);
            Perguntas.Add(pergunta10);
            
        }

        private void MostrarPergunta(Pergunta pergunta)
        {
            LabelPontuacao.Content = "Pontuação " + Jogador.Pontuacao;
            TextBlockEnunciado.Text = pergunta.Enunciado;
            RadioButtonResposta1.Content = pergunta.Resposta1;
            RadioButtonResposta2.Content = pergunta.Resposta2;
            RadioButtonResposta3.Content = pergunta.Resposta3;
            RadioButtonResposta4.Content = pergunta.Resposta4;
            RadioButtonResposta5.Content = pergunta.Resposta5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nome = TextBoxNomeJogador.Text;
            this.Jogador = new Jogador(nome, 0);
            GridTelaAbertura.Visibility = Visibility.Hidden;
            GridTelaPergunta.Visibility = Visibility.Visible;

            LabelNomeJogador.Content = 
                this.Jogador.Nome 
                + " jogando";

            MostrarPergunta(Perguntas[0]);

            Console.WriteLine(this.Jogador.Nome);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Checar se a resposta está correta
            var perguntaAtual = Perguntas[IDPerguntaAtual];
            var respostaPergunta = perguntaAtual.RespostaCorreta;

            int respostaSelecionada = 0;

            if(RadioButtonResposta1.IsChecked.Value) respostaSelecionada = 1;
            else if(RadioButtonResposta2.IsChecked.Value) respostaSelecionada = 2;
            else if(RadioButtonResposta3.IsChecked.Value) respostaSelecionada = 3;
            else if(RadioButtonResposta4.IsChecked.Value) respostaSelecionada = 4;
            else if(RadioButtonResposta5.IsChecked.Value) respostaSelecionada = 5;        

            if(respostaSelecionada == respostaPergunta)
            {
                Jogador.Pontuacao = Jogador.Pontuacao + 10;
            }
            else
            {
                MostrarFinal();
            }

            IDPerguntaAtual = IDPerguntaAtual + 1;

            if(IDPerguntaAtual < Perguntas.Count)
            {
                MostrarPergunta(Perguntas[IDPerguntaAtual]);
            }
            else
            {
                MostrarFinal();
            }
        }

        private void MostrarFinal()
        {
            GridTelaPergunta.Visibility = Visibility.Hidden;
            GridTelaFinal.Visibility = Visibility.Visible;

            TextBlockFinal.Text =
                "O jogo acabou!\n A sua pontuação foi: " +
                Jogador.Pontuacao +
                " pontos!";
        }
    }

    public class Pergunta
    {
        public string Enunciado;
        public string Resposta1;
        public string Resposta2;
        public string Resposta3;
        public string Resposta4;
        public string Resposta5;
        public int RespostaCorreta;
    }
}
