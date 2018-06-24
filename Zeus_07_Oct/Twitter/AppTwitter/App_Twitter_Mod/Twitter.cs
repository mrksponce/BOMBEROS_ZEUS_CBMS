using System;
using System.Collections.Generic;
using System.Text;
using Twitterizer;
using Zeus.Data;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace App_Twitter_Mod
{
    class Twitter
    {
        public static System.Timers.Timer tiempo = new System.Timers.Timer();
        public static bool estadoDemonio = true;
        public static bool estadoTiempoTranscurrido = false;

        
        public void GenerarTwitt(int idExpediente, string invokeTwitter, string carrosDespachados)
        {
            // ### Twitter del Mapa
            TwittLinea2(idExpediente, invokeTwitter, carrosDespachados);
            
            // ### Twitter del Despacho
            TwittLinea1(idExpediente, invokeTwitter, carrosDespachados);
        }

        static void tiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            estadoTiempoTranscurrido = true;
            tiempo.Enabled = false;
        }

        public void SetLog(string informacion)
        {
            string fecha = System.DateTime.Now.ToString();
            string fic = @"C:\comander\app_twitter\log_twitter\log_["+fecha+"]_twitter.txt";
            StreamWriter sw = new StreamWriter(fic);
            System.IO.File.Create(fic);
            string strComentario = "Fecha ["+fecha+"] Log: " + informacion;
            sw.WriteLine(strComentario);
            sw.Close();
        }

        public void TwittLinea1(int idExpediente, string invokeTwitter, string carrosDespachados)
        {

                e_expedientes exp = new e_expedientes();
                OAuthTokens tokens = new OAuthTokens();
                string twitt_enviar = "";

                // ### TW Ok CBMS
                tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
                tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
                tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
                tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";
             
                 
                foreach (DataRow rDatos in exp.GetDatosTwitter(idExpediente).Tables[0].Rows)
                {
                    if (invokeTwitter == "FT1")
                    {
                        twitt_enviar = "" + rDatos["clave"].ToString() + " " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT2")
                    {
                        int intPrincipal = Convert.ToInt32(rDatos["codigo_principal"].ToString());
                        if (intPrincipal > 49)
                        {
                            twitt_enviar = "SALE " + carrosDespachados + " A INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                        }
                        else
                        {
                            twitt_enviar = "SALE " + carrosDespachados + " A " + rDatos["clave"].ToString() + " " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                        }
                    }

                    //### Incendios Estructural
                    if (invokeTwitter == "FT3")
                    {
                        twitt_enviar = "1er. BATALLON DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["material_despachado"].ToString() + " ";
                    }

                    if (invokeTwitter == "FT4")
                    {
                        twitt_enviar = "2do. BATALLON DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT5")
                    {
                        twitt_enviar = "3er. BATALLON DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT6")
                    {
                        twitt_enviar = "4to. BATALLON DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT7")
                    {
                        twitt_enviar = "5ta ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT8")
                    {
                        twitt_enviar = "6ta ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT9")
                    {
                        twitt_enviar = "7ma ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    //### Incendios Forestal
                    if (invokeTwitter == "FT3F")
                    {
                        twitt_enviar = "INCENDIO FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["material_despachado"].ToString() + " ";
                    }

                    if (invokeTwitter == "FT4F")
                    {
                        twitt_enviar = "2da ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT5F")
                    {
                        twitt_enviar = "3ra ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT6F")
                    {
                        twitt_enviar = "4ta ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT7F")
                    {
                        twitt_enviar = "5ta ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT8F")
                    {
                        twitt_enviar = "6ta ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    if (invokeTwitter == "FT9F")
                    {
                        twitt_enviar = "7ma ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    }

                    //### API 1.1
                    StatusUpdateOptions options = new StatusUpdateOptions();
                    options.InReplyToStatusId = 12345;
                    options.APIBaseAddress = "https://api.twitter.com/1.1/";
                    options.UseSSL = true;

                    TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar, options);

                    if (tweetResponse.Result == RequestResult.Success)
                    {
                        //SetLog("Twitteo generador con fecha " + System.DateTime.Now.ToString() + ", OK");
                        //### int intVal = EscribeLogTwitter(tweetResponse.Result.ToString());
                    }
                    else
                    {
                        //SetLog("Con fecha " + System.DateTime.Now.ToString() + " el twitteo no se genero, el motivo: [" + tweetResponse.Result + "], NOOK");
                        //### int intVal = EscribeLogTwitter(tweetResponse.Result.ToString());
                    }
                }
        }


        //### Twitter con Mapa
        public void TwittLinea2(int idExpediente, string invokeTwitter, string carrosDespachados)
        {

            e_expedientes exp = new e_expedientes();
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar2 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";





            foreach (DataRow rDatos in exp.GetDatosTwitter(idExpediente).Tables[0].Rows)
            {

                if (invokeTwitter == "FT1")
                {
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa del " + rDatos["clave"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                    //twitt_enviar2 = "Ubicación del " + rDatos["clave"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + "";   //rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT2")
                {
                    int intPrincipal = Convert.ToInt32(rDatos["codigo_principal"].ToString());
                    if (intPrincipal > 49)
                    {
                        twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa del Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                    }
                    else
                    {
                        twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa del " + rDatos["clave"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                    }
                }

                //### Incendios Estructural
                if (invokeTwitter == "FT3")
                {
                    //twitt_enviar = "INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["material_despachado"].ToString() + " ";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa del Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT4")
                {
                    //twitt_enviar = "2DA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 2da Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT5")
                {
                    //twitt_enviar = "3RA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 3ra Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT6")
                {
                    //twitt_enviar = "4TA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 4ta Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT7")
                {
                    //twitt_enviar = "5TA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 5ta Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                    
                }

                if (invokeTwitter == "FT8")
                {
                    //twitt_enviar = "6TA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 6ta Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT9")
                {
                    //twitt_enviar = "7MA ALARMA DE INCENDIO " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 7ma Alarma de Incendio (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }


                //### Incendios Forestal
                if (invokeTwitter == "FT3F")
                {
                    //twitt_enviar = "INCENDIO FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["material_despachado"].ToString() + " ";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa Incendio Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT4F")
                {
                    //twitt_enviar = "2DA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 2da Alarma Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT5F")
                {
                    //twitt_enviar = "3RA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 3ra Alarma Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT6F")
                {
                    //twitt_enviar = "4TA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 4ta Alarma Fores (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT7F")
                {
                    //twitt_enviar = "5TA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 5ta Alarma Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT8F")
                {
                    //twitt_enviar = "6TA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 6ta Alarma Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }

                if (invokeTwitter == "FT9F")
                {
                    //twitt_enviar = "7MA ALARMA FORESTAL " + rDatos["seis2"].ToString() + " / " + rDatos["cero5"].ToString() + " " + carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ")";
                    twitt_enviar2 = "[" + rDatos["comuna"].ToString() + "] [Area: " + rDatos["id_area"].ToString() + "] Mapa 7ma Alarma Forestal (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";
                }                
                //twitt_enviar2 = "Ubicación del " + rDatos["clave"].ToString() +" "+ carrosDespachados + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") " + rDatos["plano"].ToString() + "";


                //### API 1.1
                StatusUpdateOptions options = new StatusUpdateOptions();
                options.InReplyToStatusId = 12345;
                options.APIBaseAddress = "https://api.twitter.com/1.1/";
                options.UseSSL = true;
                
                //TwitterResponse<TwitterStatus> tweetResponse2 = TwitterStatus.Update(tokens, twitt_enviar2);
                TwitterResponse<TwitterStatus> tweetResponse2 = TwitterStatus.Update(tokens, twitt_enviar2, options);


                if (tweetResponse2.Result == RequestResult.Success)
                {
                    //SetLog("Twitteo generador con fecha " + System.DateTime.Now.ToString() + ", OK");
                    //int intVal = EscribeLogTwitter(tweetResponse2.Result.ToString());
                }
                else
                {
                    //SetLog("Con fecha " + System.DateTime.Now.ToString() + " el twitteo no se genero, el motivo: [" + tweetResponse2.Result + "], NOOK");
                    //int intVal = EscribeLogTwitter(tweetResponse2.Result.ToString());
                }
            }


        }



        public static int EscribeLogTwitter(string strNom)
        {
            int Resulta = 0;
            string fic = @"C:\comander\log_twitter.txt";

            StreamWriter sw = new StreamWriter(fic);
            //string strComentario = " Ranking # Id_Carro # Id_Compañia";
            string strXeY = "";
            sw.WriteLine(strNom);

            //for (int c = 0; c < RankingList.Count; c++)
            //{
            //    string strRan = RankingList[c].ToString();
            //    string strIdCar = IdCarro[c].ToString();
            //    string strIdCia = IdCia[c].ToString();
            //    sw.WriteLine(strRan + "  #  " + strIdCar + "  #  " + strIdCia);
            //}
            sw.Close();
            return Resulta;
        }





        // ### Twitter de Texto Libre y Clave 0-9
        public void GenerarTwitt_Texto(string strText)
        {

            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";


            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";


            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
      
        }


        // ### Twitter de Clave 0-8 Taller Parte I
        public void GenerarTwitt_08tl_I(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }

        // ### Twitter de Clave 0-8 Taller Parte II
        public void GenerarTwitt_08tl_II(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }


        // ### Twitter de Clave 0-8 Sin Conductor Parte I
        public void GenerarTwitt_08sc_I(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }

        // ### Twitter de Clave 0-8 Sin Conductor Parte II
        public void GenerarTwitt_08sc_II(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }


        // ### Twitter de Clave En Acto Parte I
        public void GenerarTwitt_EnActo_I(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";


            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }

        // ### Twitter de Clave En Acto Parte II
        public void GenerarTwitt_EnActo_II(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }


        // ### Twitter de Clave 6-8 Parte I
        public void GenerarTwitt_68_I(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }

        // ### Twitter de Clave 6-8 Parte II
        public void GenerarTwitt_68_II(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";

            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }


        // ### Twitter de Clave 0-9 Parte I
        public void GenerarTwitt_09_I(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";


            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }

        // ### Twitter de Clave 0-9 Parte II
        public void GenerarTwitt_09_II(string strText)
        {
            OAuthTokens tokens = new OAuthTokens();
            string twitt_enviar3 = "";

            // ### TW Ok CBMS
            tokens.AccessToken = "1258537242-wMFPksYBAxEI2Q09C0mKDBJ6h4JLALPZGARdpfI";
            tokens.AccessTokenSecret = "S8cqL39kbK33UKEPlMQn4446NEl6PYdevdZkNIYc";
            tokens.ConsumerKey = "6ESBNpQiO3sAd3kPMMMbNA";
            tokens.ConsumerSecret = "B8PUYhI2J5FtAfmVmZEs9NK7WP1Eak2Ph8rayKrvho";


            twitt_enviar3 = strText + " (" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + ") ";

            //### API 1.1
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.InReplyToStatusId = 12345;
            options.APIBaseAddress = "https://api.twitter.com/1.1/";
            options.UseSSL = true;

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, twitt_enviar3, options);
        }



        // ### Twitter de Reporte de Estado del Material Mayor
        public void GenerarTwitt_Reporte()
        {
            z_carros zcarros = new z_carros();
            string strRep_09 = "";
            string strRep_08tl = "";
            string strRep_08sc = "";
            string strRep_Acto = "";
            string strRep_68 = "";

            //### Obtener el Estado del Material Mayor
            foreach (DataRow rDatos in zcarros.GetEstadosTwitter().Tables[0].Rows)
            {
                switch (Convert.ToInt32(rDatos["estado"].ToString()))
                {
                    case 1: //# Carros 0-9
                        strRep_09 += rDatos["nombre"].ToString() + ", ";
                        break;

                    case 2: //# Carros 0-8 En Taller
                        strRep_08tl += rDatos["nombre"].ToString() + ", ";
                        break;

                    case 3: //# Carros 0-8 Sin Conductor
                        strRep_08sc += rDatos["nombre"].ToString() + ", ";
                        break;

                    case 4: //# Carros En Acto
                        strRep_Acto += rDatos["nombre"].ToString() + ", ";
                        break;

                    case 5: //# Carros 6-8
                        strRep_68 += rDatos["nombre"].ToString() + ", ";
                        break;
                }
            }


            //### Publicar Twitter por Cada Estado
            int intCaracteres = 0;

            string strFinBoletin = "Boletin Informativo del Material Mayor C.B. Metropolitano Sur";
            GenerarTwitt_Texto(strFinBoletin);

            //### Material Mayor 0-8 en Taller
            if (strRep_08tl != "")
            {
                string strRep_08tl_v2 = strRep_08tl + "#";
                strRep_08tl_v2 = "0-8 En Taller : " + strRep_08tl_v2.ToString().Replace(", #", "");
                //GenerarTwitt_08tl(strRep_08tl_v2);
                intCaracteres = strRep_08tl_v2.Length;
                if (intCaracteres <= 127)
                {
                    GenerarTwitt_08tl_I(strRep_08tl_v2);
                }
                else
                {
                    string strTw_1_08tl = "";
                    string strTw_2_08tl = "";
                    string strRep_08tl_v3 = strRep_08tl + "#";
                    strRep_08tl_v3 = strRep_08tl_v3.ToString().Replace(", #", "");
                    string[] Carros_08tl = strRep_08tl_v3.Split(' ');
                    int Mitad_08tl = Convert.ToInt32(decimal.Truncate(Carros_08tl.Length / 2));

                    //# Segunda Mitad
                    for (int i = Mitad_08tl; i < Carros_08tl.Length; i++)
                    {
                        strTw_2_08tl += Carros_08tl[i].ToString() + " ";
                    }
                    strTw_2_08tl = "0-8 En Taller : " + strTw_2_08tl;
                    GenerarTwitt_08tl_II(strTw_2_08tl);                    
                    
                    //# Primera Mitad
                    for (int i = 0; i < Mitad_08tl; i++)
                    {
                        strTw_1_08tl += Carros_08tl[i].ToString() + " ";
                    }
                    strTw_1_08tl = strTw_1_08tl + "#";
                    strTw_1_08tl = "0-8 En Taller : " + strTw_1_08tl.ToString().Replace(", #", "");
                    GenerarTwitt_08tl_I(strTw_1_08tl);
                }
            }


            //### Material Mayor 0-8 Sin Conductor
            if (strRep_08sc != "")
            {
                string strRep_08sc_v2 = strRep_08sc + "#";
                strRep_08sc_v2 = "0-8 Disponible : " + strRep_08sc_v2.ToString().Replace(", #", "");
                //GenerarTwitt_08sc(strRep_08sc_v2);
                intCaracteres = strRep_08sc_v2.Length;
                if (intCaracteres <= 127)
                {
                    GenerarTwitt_08sc_I(strRep_08sc_v2);
                }
                else
                {
                    string strTw_1_08sc = "";
                    string strTw_2_08sc = "";
                    string strRep_08sc_v3 = strRep_08sc + "#";
                    strRep_08sc_v3 = strRep_08sc_v3.ToString().Replace(", #", "");
                    string[] Carros_08sc = strRep_08sc_v3.Split(' ');
                    int Mitad_08sc = Convert.ToInt32(decimal.Truncate(Carros_08sc.Length / 2));

                    //# Segunda Mitad
                    for (int i = Mitad_08sc; i < Carros_08sc.Length; i++)
                    {
                        strTw_2_08sc += Carros_08sc[i].ToString() + " ";
                    }
                    strTw_2_08sc = "0-8 Disponible : " + strTw_2_08sc;
                    GenerarTwitt_08sc_II(strTw_2_08sc);                    
                    
                    //# Primera Mitad
                    for (int i = 0; i < Mitad_08sc; i++)
                    {
                        strTw_1_08sc += Carros_08sc[i].ToString() + " ";
                    }
                    strTw_1_08sc = strTw_1_08sc + "#";
                    strTw_1_08sc = "0-8 Disponible : " + strTw_1_08sc.ToString().Replace(", #", "");
                    GenerarTwitt_08sc_I(strTw_1_08sc);
                }
            }


            //### Material Mayor 0-9
            if (strRep_09 != "")
            {
                string strRep_09_v2 = strRep_09 + "#";
                strRep_09_v2 = "0-9 : " + strRep_09_v2.ToString().Replace(", #", "");
                intCaracteres = strRep_09_v2.Length;
                if (intCaracteres <= 127)
                {
                    GenerarTwitt_09_I(strRep_09_v2);
                }
                else
                {
                    string strTw_1 = "";
                    string strTw_2 = "";
                    string strRep_09_v3 = strRep_09 + "#";
                    strRep_09_v3 = strRep_09_v3.ToString().Replace(", #", "");
                    string[] Carros_09 = strRep_09_v3.Split(' ');
                    int Mitad_09 = Convert.ToInt32(decimal.Truncate(Carros_09.Length / 2));

                    //# Segunda Mitad
                    for (int i = Mitad_09; i < Carros_09.Length; i++)
                    {
                        strTw_2 += Carros_09[i].ToString() + " ";
                    }
                    strTw_2 = "0-9 : " + strTw_2;
                    GenerarTwitt_09_II(strTw_2);
                    
                    //# Primera Mitad
                    for (int i = 0; i < Mitad_09; i++)
                    {
                        strTw_1 += Carros_09[i].ToString() + " ";
                    }
                    strTw_1 = strTw_1 + "#";
                    strTw_1 = "0-9 : " + strTw_1.ToString().Replace(", #", "");
                    GenerarTwitt_09_I(strTw_1);
                }
            }


            //### Material Mayor 6-8
            if (strRep_68 != "")
            {
                string strRep_68_v2 = strRep_68 + "#";
                strRep_68_v2 = "6-8 : " + strRep_68_v2.ToString().Replace(", #", "");
                //GenerarTwitt_68(strRep_68_v2);
                intCaracteres = strRep_68_v2.Length;
                if (intCaracteres <= 127)
                {
                    GenerarTwitt_68_I(strRep_68_v2);
                }
                else
                {
                    string strTw_1_68 = "";
                    string strTw_2_68 = "";
                    string strRep_68_v3 = strRep_68 + "#";
                    strRep_68_v3 = strRep_68_v3.ToString().Replace(", #", "");
                    string[] Carros_68 = strRep_68_v3.Split(' ');
                    int Mitad_68 = Convert.ToInt32(decimal.Truncate(Carros_68.Length / 2));

                    //# Segunda Mitad
                    for (int i = Mitad_68; i < Carros_68.Length; i++)
                    {
                        strTw_2_68 += Carros_68[i].ToString() + " ";
                    }
                    strTw_2_68 = "6-8 : " + strTw_2_68;
                    GenerarTwitt_68_II(strTw_2_68);
                    
                    //# Primera Mitad
                    for (int i = 0; i < Mitad_68; i++)
                    {
                        strTw_1_68 += Carros_68[i].ToString() + " ";
                    }
                    strTw_1_68 = strTw_1_68 + "#";
                    strTw_1_68 = "6-8 : " + strTw_1_68.ToString().Replace(", #", "");
                    GenerarTwitt_68_I(strTw_1_68);
                }

            }


            //### Material Mayor en Acto
            if (strRep_Acto != "")
            {
                string strRep_Acto_v2 = strRep_Acto + "#";
                strRep_Acto_v2 = "En Acto : " + strRep_Acto_v2.ToString().Replace(", #", "");
                //GenerarTwitt_EnActo(strRep_Acto_v2);
                intCaracteres = strRep_Acto_v2.Length;
                if (intCaracteres <= 127)
                {
                    GenerarTwitt_EnActo_I(strRep_Acto_v2);
                }
                else
                {
                    string strTw_1_08act = "";
                    string strTw_2_08act = "";
                    string strRep_08act_v3 = strRep_Acto + "#";
                    strRep_08act_v3 = strRep_08act_v3.ToString().Replace(", #", "");
                    string[] Carros_08act = strRep_08act_v3.Split(' ');
                    int Mitad_08act = Convert.ToInt32(decimal.Truncate(Carros_08act.Length / 2));

                    //# Segunda Mitad
                    for (int i = Mitad_08act; i < Carros_08act.Length; i++)
                    {
                        strTw_2_08act += Carros_08act[i].ToString() + " ";
                    }
                    strTw_2_08act = "En Acto : " + strTw_2_08act;
                    GenerarTwitt_EnActo_II(strTw_2_08act);
                    
                    //# Primera Mitad
                    for (int i = 0; i < Mitad_08act; i++)
                    {
                        strTw_1_08act += Carros_08act[i].ToString() + " ";
                    }
                    strTw_1_08act = strTw_1_08act + "#";
                    strTw_1_08act = "En Acto : " + strTw_1_08act.ToString().Replace(", #", "");
                    GenerarTwitt_EnActo_I(strTw_1_08act);
                }
            }

            string strInicioBoletin = "Boletin Informativo del Material Mayor C.B. Metropolitano Sur";
            GenerarTwitt_Texto(strInicioBoletin);
        }

    }
}

