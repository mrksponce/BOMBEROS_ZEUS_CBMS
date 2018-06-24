using System;
using System.Collections.Generic;
using System.Text;
using Twitterizer;
using Zeus.Data;
using System.Data;

namespace Zeus.UIElements
{
    class Twitter
    {
        public void GenerarTwitt(int idExpediente)
        {
            e_expedientes exp = new e_expedientes();
            OAuthTokens tokens = new OAuthTokens();
            tokens.AccessToken = "159491023-draDmhFMlDEBqPwxxvdxMj25PmeE4STUW13zgnTr";
            tokens.AccessTokenSecret = "b8TkheJF2OKRHPjrADL0ClZ3p9JQrGFZLngTHTpe0Ek";
            tokens.ConsumerKey = "0KQaHGQWipyYWirvXJQnXw";
            tokens.ConsumerSecret = "DBtrwcbYy1hsHKb7NhisGKpqOErdNK1KkGXLu3sNPE";
            foreach (DataRow rDatos in exp.GetDatosTwitter(idExpediente).Tables[0].Rows)
            {
                string twitt_enviar = rDatos["clave"].ToString() + " " + rDatos["seis2"].ToString() + " Y " + rDatos["cero5"].ToString() + " AREA " + rDatos["id_area"].ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar + ", #Twitterizer");
                if (tweetResponse.Result == RequestResult.Success)
                {
                    string aa = "TWIT!";
                }
                else
                {
                    string aa = "NO TWIT!";
                }
            }

            //OAuthTokens tokens = new OAuthTokens();
            //tokens.AccessToken = "159491023-draDmhFMlDEBqPwxxvdxMj25PmeE4STUW13zgnTr";
            //tokens.AccessTokenSecret = "b8TkheJF2OKRHPjrADL0ClZ3p9JQrGFZLngTHTpe0Ek";
            //tokens.ConsumerKey = "0KQaHGQWipyYWirvXJQnXw";
            //tokens.ConsumerSecret = "DBtrwcbYy1hsHKb7NhisGKpqOErdNK1KkGXLu3sNPE";

            //TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, "Generando TWITTS DESDE .NET!!!, #Twitterizer");
            //if (tweetResponse.Result == RequestResult.Success)
            //{
            //    string aa = "TWIT!";
            //}
            //else
            //{
            //    string aa = "NO TWIT!";
            //}
        }
    }
}
