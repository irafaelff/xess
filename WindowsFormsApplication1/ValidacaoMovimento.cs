using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    static class ValidacaoMovimento
    {


       public static bool validaTorre(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
           int letra = 0;
           int linha = 1;

           if (posicaoOrigem.coordenada[letra] == posicaoDestino.coordenada[letra] &
               posicaoOrigem.coordenada[linha] != posicaoDestino.coordenada[linha])
           {
               return true;
           }
           else if (posicaoOrigem.coordenada[letra] != posicaoDestino.coordenada[letra] &
               posicaoOrigem.coordenada[linha] == posicaoDestino.coordenada[linha])
           {
               return true;
           }

           return false;
        }


    }

}
