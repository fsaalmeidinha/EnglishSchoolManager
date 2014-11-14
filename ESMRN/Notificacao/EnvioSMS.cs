using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace EnglishSchoolManagerRules.Notificacao
{
    public class EnvioSMS
    {
        //http://mobilepronto.info/samples/pt-br/1200-httpget-vb.net-v_2_00.pdf

        static string URLServico = "https://www.mpgateway.com/v_2_00/smspush/enviasms.aspx";
        static string credencialServico = "9431BA77CC1E462F8B071445C4921C39EB1925B4";
        static string usuarioPrincipal = "ENGLISHSCHOOLMANAG";
        static string usuarioAuxiliar = "felipe.silvalmeida@gmail.com";
        static string enviarProjetoNoFrom = "S";

        public static void EnviarSMS(string numeroCelular, string mensagem)
        {
            try
            {
                string urlServicoComParametros = String.Format("{0}?CREDENCIAL={1}&PRINCIPAL_USER={2}&AUX_USER={3}&MOBILE={4}&SEND_PROJECT={5}&MESSAGE={6}",
                    URLServico, credencialServico, Uri.EscapeDataString(usuarioPrincipal), Uri.EscapeDataString(usuarioAuxiliar), numeroCelular, enviarProjetoNoFrom, Uri.EscapeDataString(mensagem));

                HttpWebRequest webRequest = WebRequest.Create(urlServicoComParametros) as HttpWebRequest;
                WebResponse resposta = webRequest.GetResponse();

                if (resposta != null)
                {
                    StreamReader streamReader = new StreamReader(resposta.GetResponseStream());
                    string codigoRetorno = streamReader.ReadToEnd();
                    streamReader.Close();
                    resposta.Close();

                    if (codigoRetorno == "000")
                    {

                    }
                    else
                    {
                        //TODO: Verificar erros..

                    }
                }
                else
                {
                    //TODO: Verificar erros..
                    //X01 ou X02 – Parâmetros com Erro.
                    //000 - Mensagem enviada com Sucesso.
                    //001 - Credencial Inválida.
                    //005 - Mobile fora do formato-Formato +999(9999)99999999.
                    //007 - SEND_PROJECT tem que ser S, ou N.
                    //008 - Mensagem ou FROM+MESSAGE maior que 142 posições.
                    //009 - Sem crédito para envio de SMS. Favor repor.
                    //010 - Gateway Bloqueado.
                    //012 - Mobile no formato padrão, mas incorreto.
                    //013 - Mensagem Vazia ou Corpo Inválido
                    //015 - Pais sem operação.
                    //016 - Mobile com tamanho do código de área inválido.
                    //017 - Operadora não autorizada para esta Credencial.
                    //De 800 a 899 - Falha no gateway Mobile Pronto. Contate suporte Mobile Pronto.
                    //900 - Erro de autenticação ou Limite de segurança excedido.
                    //De 901 a 999 - Erro no acesso as operadoras
                }
            }
            catch (Exception ex)
            {
                //TODO: Verificar erros..
            }
        }
    }
}
