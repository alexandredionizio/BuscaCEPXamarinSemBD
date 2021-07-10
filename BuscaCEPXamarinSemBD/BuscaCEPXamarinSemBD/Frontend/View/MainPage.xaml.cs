using BuscaCEPXamarinSemBD.Backend.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscaCEPXamarinSemBD
{
    public partial class MainPage : ContentPage
    {
        private Pessoa_Service pessoa_service = new Pessoa_Service();
        private Cep_Service cep_service = new Cep_Service();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnBuscarEndereco_Clicked(object sender, EventArgs e)
        {
            var cep = etCep.Text;
            var resposta = await cep_service.Get(cep);

            if (resposta.Sucesso)
            {
                this.cep_service.Create(resposta.cep_model);

                await DisplayAlert(cep,
                    "Logradouro " + resposta.cep_model.logradouro +
                    "\nBairro " + resposta.cep_model.bairro +
                    "\nLogradouro " + resposta.cep_model.uf,
                    "OK");
            }
            else
            {
                await DisplayAlert("Aviso",
                    "Não foi possivel efetuar a operação\n" + resposta.exception.Message,
                    "OK");
            }
        }

        private void btnBuscarCepBanco_Clicked(object sender, EventArgs e)
        {
            var cep_model = this.cep_service.Read(etFiltroIdCep.Text);
            var msg = cep_model == null ? "Nenhum CEP encontrado" : cep_model.ToString();

            DisplayAlert("Aviso", msg, "Ok");
        }
    }
}
