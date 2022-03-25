using Microsoft.Extensions.Options;
using Sistema.Detran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema.Detran.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions _optionsMonitor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, IHttpClientFactory httpClientFactory, IVeiculoRepository veiculoRepository)
        {
            _optionsMonitor = optionsMonitor.CurrentValue;
            _httpClientFactory = httpClientFactory;
            _veiculoRepository = veiculoRepository;
        }
        public async Task AgendaVistoria(Guid id)
        {
            var veiculo = _veiculoRepository.GetVeiculo(id);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_optionsMonitor.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(_optionsMonitor.QuantidadeDiasParaAgendamento)
            };
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(_optionsMonitor.VistoriaUri, contentString);
        }
    }
}
