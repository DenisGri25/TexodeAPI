using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TexodeApi.Data;
using TexodeApi.Dtos;
using TexodeApi.Models;

namespace TexodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepo _repository;
        private readonly IMapper _mapper;

        public CardsController(ICardRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/cards/
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            var cardItems = _repository.GetAllCards();

            return Ok(_mapper.Map<IEnumerable<CardReadDto>>(cardItems));
        }

        //GET api/cards/{id}
        [HttpGet("{id}", Name = "GetCardById")]
        public ActionResult<CardReadDto> GetCardById(int id)
        {
            var cardItem = _repository.GetCardById(id);
            if (cardItem != null)
            {
                return Ok(_mapper.Map<CardReadDto>(cardItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CardCreateDto> CreateCard(CardCreateDto cardCreateDto)
        {
            var cardModel = _mapper.Map<Card>(cardCreateDto);
            _repository.CreateCard(cardModel);

            var cardReadDto = _mapper.Map<CardReadDto>(cardModel);

            return CreatedAtRoute(nameof(GetCardById), new {id = cardReadDto.Id}, cardReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCard(int id, CardUpdateDto cardUpdateDto)
        {
            var cardModelFromRepo = _repository.GetCardById(id);
            if (cardModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(cardUpdateDto, cardModelFromRepo);

            _repository.UpdateCard(cardModelFromRepo);

            return NoContent();
        }

        [HttpPatch]
        public ActionResult PartialCardUpdate(int id, JsonPatchDocument<CardUpdateDto> patchDoc)
        {
            var cardModelFromRepo = _repository.GetCardById(id);
            if (cardModelFromRepo == null)
            {
                return NotFound();
            }

            var cardToPatch = _mapper.Map<CardUpdateDto>(cardModelFromRepo);
            patchDoc.ApplyTo(cardToPatch, ModelState);
            if (!TryValidateModel(cardToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cardToPatch, cardModelFromRepo);

            _repository.UpdateCard(cardModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id)
        {
            var cardFromRepo = _repository.GetCardById(id);
            if (cardFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCard(cardFromRepo);

            return NoContent();
        }
    }
}
