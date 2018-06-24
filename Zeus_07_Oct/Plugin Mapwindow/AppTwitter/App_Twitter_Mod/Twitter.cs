using System;
using System.Collections.Generic;
using System.Text;
using Twitterizer;
using Zeus.Data;
using System.Data;

namespace App_Twitter_Mod
{
    class Twitter
    {
        public void GenerarTwitt(int idExpediente)
        {
            TwittLinea1(idExpediente);
            TwittLinea2(idExpediente);
        }

        public void TwittLinea1(int idExpediente)
        {
            e_expedientes exp = new e_expedientes();
            OAuthTokens tokens = new OAuthTokens();
            tokens.AccessToken = "159491023-draDmhFMlDEBqPwxxvdxMj25PmeE4STUW13zgnTr";
            tokens.AccessTokenSecret = "b8TkheJF2OKRHPjrADL0ClZ3p9JQrGFZLngTHTpe0Ek";
            tokens.ConsumerKey = "0KQaHGQWipyYWirvXJQnXw";
            tokens.ConsumerSecret = "DBtrwcbYy1hsHKb7NhisGKpqOErdNK1KkGXLu3sNPE";
            foreach (DataRow rDatos in exp.GetDatosTwitter(idExpediente).Tables[0].Rows)
            {
                string twitt_enviar = "Clave: " +rDatos["clave"].ToString() + " Fecha: " + System.DateTime.Now.ToString() + " Área: " + rDatos["id_area"].ToString() + " Lugar emergencia: " + rDatos["seis2"].ToString() + " Y " + rDatos["cero5"].ToString();
                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar);

                if (tweetResponse.Result == RequestResult.Success)
                {
                    string aa = "TWIT!";
                }
                else
                {
                    string aa = "NO TWIT!";
                }
            }
        }

        public void TwittLinea2(int idExpediente)
        {
            e_expedientes exp = new e_expedientes();
            OAuthTokens tokens = new OAuthTokens();
            tokens.AccessToken = "159491023-draDmhFMlDEBqPwxxvdxMj25PmeE4STUW13zgnTr";
            tokens.AccessTokenSecret = "b8TkheJF2OKRHPjrADL0ClZ3p9JQrGFZLngTHTpe0Ek";
            tokens.ConsumerKey = "0KQaHGQWipyYWirvXJQnXw";
            tokens.ConsumerSecret = "DBtrwcbYy1hsHKb7NhisGKpqOErdNK1KkGXLu3sNPE";
            foreach (DataRow rDatos in exp.GetDatosTwitter(idExpediente).Tables[0].Rows)
            {
                string twitt_enviar2 = rDatos["clave"].ToString() + "   " + System.DateTime.Now.ToString() + "   " + rDatos["id_area"].ToString() + "   " + rDatos["seis2"].ToString() + " Y " + rDatos["cero5"].ToString() + "   Material Despachado:" + rDatos["material_despachado"].ToString() + "";
                TwitterResponse<TwitterStatus> tweetResponse2 = TwitterStatus.Update(tokens, twitt_enviar2);

                if (tweetResponse2.Result == RequestResult.Success)
                {
                    string aa = "TWIT!";
                }
                else
                {
                    string aa = "NO TWIT!";
                }
            }
        }
    }
}

