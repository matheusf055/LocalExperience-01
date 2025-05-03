using LocalExperience.AppServices.Interfaces.Itineraries;
using LocalExperience.AppServices.Itineraries.DTOs;
using LocalExperience.Domain.Itineraries;
using LocalExperience.Domain.Itineraries.Repositories;
using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Trips.Repositories;
using LocalExperience.Infrastructure.ExternalServices.ChatGpt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Itineraries
{
    public class ItineraryAppService : IItineraryAppService
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly ITripRepository _tripRepository;
        private readonly ChatGptService _chatGptService;

        public ItineraryAppService(IItineraryRepository itineraryRepository, ITripRepository tripRepository, ChatGptService chatGptService)
        {
            _itineraryRepository = itineraryRepository;
            _tripRepository = tripRepository;
            _chatGptService = chatGptService;
        }

        public async Task<ItineraryDto> GetById(Guid id)
        {
            var itinerary = await _itineraryRepository.GetById(id);
            if (itinerary == null) throw new KeyNotFoundException("Roteiro não foi encontrado.");

            return new ItineraryDto
            {
                Id = itinerary.Id,
                TripId = itinerary.TripId,
                Summary = itinerary.Summary,
                CreateDate = itinerary.CreateDate
            };
        }

        public async Task Create(CreateItineraryDto itineraryDto)
        {
            var trip = await _tripRepository.GetByIdWithDetails(itineraryDto.TripId);
            if (trip == null) throw new KeyNotFoundException("Viagem não encontrada.");

            if (trip.TripsInterestProfile == null) throw new InvalidOperationException("O perfil de interesses da viagem não foi encontrado.");

            var prompt = BuildPrompt(trip);

            var summary = await _chatGptService.GenerateItinerary(prompt);

            var itinerary = new Itinerary
            {
                TripId = trip.Id,
                Summary = summary,
            };

            await _itineraryRepository.Create(itinerary);
        }

        private static string BuildPrompt(Trip trip)
        {
            var interests = trip.TripsInterestProfile.GetInterestSummary();

            return
                $"Gere um itinerário de viagem dia a dia para o destino {trip.Destination} " +
                $"entre os dias {trip.StartDate:dd/MM/yyyy} e {trip.EndDate:dd/MM/yyyy}. " +
                $"O usuário tem interesse em: {interests}. " +
                $"Formate o texto com dias separados e sugestões curtas.";
        }

        public async Task Update(UpdateItineraryDto itineraryDto)
        {
            var itinerary = await _itineraryRepository.GetById(itineraryDto.Id);
            if (itinerary == null) throw new KeyNotFoundException("Roteiro não foi encontrado.");

            itinerary.Summary = itineraryDto.Summary;

            await _itineraryRepository.Update(itinerary);
        }

        public async Task Delete(Guid id)
        {
            var itinerary = await _itineraryRepository.GetById(id);
            if (itinerary == null) throw new KeyNotFoundException("Roteiro não foi encontrado.");

            await _itineraryRepository.Delete(id);
        }
    }
}
