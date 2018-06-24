using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using Zeus.Data;

namespace Zeus.Util
{
    public class LocalizacionGPS : MarshalByRefObject
    {
        public static void StartServer()
        {
            // Abrir canal linux
            //TcpChannel channel = new TcpChannel(5430);
            //ChannelServices.RegisterChannel(channel, false);

            // abrir canal windows
            var serv = new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};
            //TcpServerChannel channel = new TcpServerChannel("server_localizacion", 5430, serv);
            var channel = new HttpServerChannel("server_localizacion", 5430, serv);
            ChannelServices.RegisterChannel(channel, false);

            // Publicar servicio
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof (LocalizacionGPS),
                "LocalizacionGPS",
                WellKnownObjectMode.Singleton);
            //System.Console.WriteLine("Press the enter key to exit…");
            //Console.In.ReadLine();
        }

        public static LocalizacionGPS StartClient()
        {
            //BinaryClientFormatterSinkProvider bc = new BinaryClientFormatterSinkProvider();

            //TcpClientChannel chan = new TcpClientChannel();
            //HttpClientChannel chan = new HttpClientChannel();
            ChannelServices.RegisterChannel(
                new HttpClientChannel("client_localizacion", new BinaryClientFormatterSinkProvider()), false);


            //ChannelServices.RegisterChannel(chan, false);

            // Create an instance of the remote object
            var obj = (LocalizacionGPS) Activator.GetObject(
                                                        typeof (LocalizacionGPS),
                                                        //"tcp://" + Data.Config.Host + ":5430/LocalizacionGPS");
                                                        "http://" + Config.Host + ":5430/LocalizacionGPS");

            return obj;
        }

        public Localizacion Localizar(int id_carro)
        {
            //
            // localiza carro dada su ID
            var l = new Localizacion();
            var r = new Random();
            l.Identificacion = id_carro;
            l.Latitud = 33.54902 + 0.094783333*r.NextDouble();
            l.Longitud = 70.61131667 + 0.078533333*r.NextDouble();

            return l;
        }

        public string Localizar_s(int id_carro)
        {
            Localizacion l = Localizar(id_carro);
            return l.ToString(false);
        }

        public EstadoNiveles EstadoNiveles(int id_carro)
        {
            var r = new Random();

            var en = new EstadoNiveles
                         {
                             Identificacion = id_carro,
                             Agua = r.Next(7),
                             Combustible = r.Next(5),
                             Pulsador = (r.Next(2) != 0 ? true : false)
                         };
            return en;
        }

        public string EstadoNiveles_s(int id_carro)
        {
            EstadoNiveles en = EstadoNiveles(id_carro);
            return en.ToString(false);
        }
    }
}