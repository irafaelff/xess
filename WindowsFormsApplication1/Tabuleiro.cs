using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Tabuleiro : Form
    {

        Posicao[,] posicoes = new Posicao[8,8];
        Posicao posicaoSelecionada;

        public Tabuleiro()
        {
            InitializeComponent();
           

            criaPosicoes();

            posicionarPecasInicio();
        }

        void criaPosicoes()
        {
             
            int i, x, posX, posY;
            Posicao posicao;
                     
            posX = 0;
            posY = 0;

            string[] letras = new string[] {"A", "B", "C", "D", "E", "F", "G", "H"};
            
            Boolean cor;
            cor = false;
            for (i = 0; i < 8; i++) //Avança linha
            {

                if (i == 0)
                    posY = 410;
                else
                    posY = posY - 49;

                if (cor)
                    cor = false;
                else
                    cor = true;

                for (x = 0; x < 8; x++) //Avança coluna
                {
                    if (x == 0)
                        posX = 1;
                    else
                        posX = posX + 49;


                    posicao = new Posicao();
                    posicao.Width = 50; //Largura
                    posicao.Height = 50; //Altura
                    posicao.Location = new Point(posX, posY);
                    posicao.coordenada = new string[2]; 
                    posicao.coordenada[0] = letras[x];
                    posicao.coordenada[1] = Convert.ToString((i + 1));

                    if (cor)
                    {
                        posicao.BackColor = Color.Gray;
                        cor = false;
                    }
                    else
                    {
                        posicao.BackColor = Color.Silver;
                        cor = true;
                    }

          
                    this.Controls.Add(posicao);
                    posicao.Text = posicao.coordenada[0] + posicao.coordenada[1];
                    
                    posicoes[x, i] = posicao;

                    posicao.Click += new EventHandler(eventClick);

                }
            }
        }

        private void eventClick(object sender, System.EventArgs e)
        {
            
            Posicao posicaoDestino;

            posicaoDestino = (Posicao)sender;

            if (posicaoDestino.ocupada == false & posicaoSelecionada == null)
                return;

            if (posicaoSelecionada == null)
            {
                if (posicaoDestino.ocupada) 
                {
                    //Seleciona a peça.
                    posicaoSelecionada = posicaoDestino;         
                }
            }
            else if (posicaoDestino.coordenada == posicaoSelecionada.coordenada)
            {
                //Se for a mesma posição deseleciona a posição.
                posicaoSelecionada = null;
            }
            else if (posicaoDestino.ocupada == false)
            {
                //Se a posição não estiver ocupada, verifico se a peça atual pode ir para a posição selecionada.

                if (podeMover(posicaoSelecionada, posicaoDestino))
                {
                    posicaoDestino.peca = posicaoSelecionada.peca;
                    posicaoDestino.Image = posicaoSelecionada.peca.Image;
                    posicaoDestino.ocupada = true;

                    posicaoSelecionada.Image = null;
                    posicaoSelecionada.ocupada = false;
                    posicaoSelecionada.peca = null;
                    posicaoSelecionada = null;
                }
            }


        }

        bool podeMover(Posicao posicaoOrigem, Posicao posicaoDestino)
        {

            
            Peca peca;
            peca = posicaoOrigem.peca;

            switch (peca.tipo)
            {
                case "TORRE":
                    return ValidacaoMovimento.validaTorre(posicaoOrigem, posicaoDestino);
                    break;
                   
                default:
                    return false;
            }

            return false;
        }

        void posicionarPecasInicio()
        {
            Posicao pAtual;
            string[] coordenada = new string[2];
            //Torres
            Peca peca;
            peca = new Peca(Properties.Resources.Torre_Preta, "BLACK", "TORRE");
            coordenada[0] = "A";
            coordenada[1] = "8";
            pAtual = buscaPosicaoPorCoordenada(coordenada);
            pAtual.peca = peca;
            pAtual.Image = peca.Image;
            pAtual.ocupada = true;

            peca = new Peca(Properties.Resources.Torre_Preta, "BLACK", "TORRE");
            coordenada[0] = "H";
            coordenada[1] = "8";
            pAtual = buscaPosicaoPorCoordenada(coordenada);
            pAtual.peca = peca;
            pAtual.Image = peca.Image;
            pAtual.ocupada = true;

            //Cavalos

            //Bispos

            //Rainhas

            //Reis

            //Peões

        }

        Posicao buscaPosicaoPorCoordenada(string[] coordenada)
        {
            int i, x;

            for (i = 0; i < 8; i++) //Avança linha
            {
                for (x = 0; x < 8; x++) //Avança coluna
                {
                    if (posicoes[x, i].coordenada[0] == coordenada[0] & posicoes[x, i].coordenada[1] == coordenada[1])
                    {
                        return posicoes[x, i];
                    }
                }
            }

            return new Posicao();
        }
    }
}
