using BuscaCEPXamarinSemBD.Backend.Repository;
using BuscaCEPXamarinSemBD.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEPXamarinSemBD.Backend.Service
{
    public class Cep_Service
    {
        private Cep_Repository repository;

        public string base_url;
        public string api_name;
        public HttpClient client;

        public Cep_Service()
        {
            repository = new Cep_Repository();

            base_url = "https://viacep.com.br";
            api_name = "/ws/{0}/json";
            client = GetClient();
        }

        #region Consumo API

        protected HttpClient GetClient()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(this.base_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
            client.Timeout = new TimeSpan(0, 2, 0);
            
            return client;
        }

        public async Task<Resposta_Model> Get(string cep)
        {
            Resposta_Model resposta_model = new Resposta_Model();
            HttpResponseMessage response = null;
            try
            {
                string api_concatenada = string.Format(this.api_name, cep);
                response = await client.GetAsync(api_concatenada);
                
                resposta_model.Sucesso = response.IsSuccessStatusCode;
                if (resposta_model.Sucesso)
                {
                    var retornoTexto = await response.Content.ReadAsStringAsync();
                    resposta_model.cep_model = JsonConvert.DeserializeObject<Cep_Model>(retornoTexto);
                }
                else
                {
                    resposta_model.exception = new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                resposta_model.Sucesso = false;
                resposta_model.exception = ex;
            }

            return resposta_model;
        }
        #endregion

        #region Consumo Repository
        public void Create(Cep_Model cep_model)
        {
            this.repository.Create(cep_model);
        }

        public Cep_Model Read(string filtro)
        {
            return this.repository.Read(filtro);
        }
        #endregion
    }

    public class Resposta_Model
    {
        public bool Sucesso { get; set; }
        public Cep_Model cep_model { get; set; }
        public Exception exception { get; set; }
    }
}