
using DespegarCore.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DespegarCore.Services
{
    public static class VuelosServices
    {
        public static List<Vuelos> GetAviancaVuelos()
        {
            var client = new RestClient("https://localhost:44325");
            var request = new RestRequest("Vuelos/IndexJson", Method.GET);

            IRestResponse<List<Vuelos>> response = client.Execute<List<Vuelos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }

        public static List<Vuelos> GetLatamVuelos()
        {
            var client = new RestClient("https://localhost:44336");

            var request = new RestRequest("Vuelos/IndexJson", Method.GET);


            IRestResponse<List<Vuelos>> response = client.Execute<List<Vuelos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }

        public static List<Vuelos> GetSatenaVuelos()
        {
            var client = new RestClient("https://localhost:44398");

            var request = new RestRequest("Vuelos/IndexJson", Method.GET);

            IRestResponse<List<Vuelos>> response = client.Execute<List<Vuelos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }
       
        public static async Task<bool> SaveReservaAvianca(Reserva reserva)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44325/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestContent = new MultipartFormDataContent();
            var values = new Dictionary<string, string>
            {
                { "IDReserva", reserva.IDReserva.ToString() },
                { "Origen", reserva.Origen },
                { "Destino", reserva.Destino },
                { "FechayHoraSalida", reserva.FechayHoraSalida.ToString() },
                { "Silla", reserva.Silla.ToString() },
                { "Clase", reserva.Clase },
                { "Precio", reserva.Precio.ToString() },
                { "NombreCliente", reserva.NombreCliente },
                { "NumeroDocumento", reserva.NumeroDocumento }                
            };
            var content = new FormUrlEncodedContent(values);
            requestContent.Add(content);

            
            HttpResponseMessage response = await client.PostAsync("Reservas/SaveReservaAPI", content);
            string responseText = await response.Content.ReadAsStringAsync();

            response.Dispose();

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public static bool SaveReservaLatam(Reserva reserva)
        {
            var client = new RestClient("https://localhost:44336");

            var request = new RestRequest("Vuelos/IndexJson", Method.POST);
            request.AddParameter("reservas", new
            {
                reserva.IDReserva,
                reserva.Origen,
                reserva.Destino,
                reserva.FechayHoraSalida,               
                reserva.Silla,
                reserva.Clase,
                reserva.Aerolinea
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static bool SaveReservaSatena(Reserva reserva)
        {
            var client = new RestClient("https://localhost:44398");

            var request = new RestRequest("Vuelos/IndexJson", Method.POST);
            request.AddParameter("reservas", new
            {
                reserva.IDReserva,
                reserva.Origen,
                reserva.Destino,
                reserva.FechayHoraSalida,
                reserva.Silla,
                reserva.Clase,
                reserva.Aerolinea
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

    }
}
