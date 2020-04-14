using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;

namespace ClinkedIn.Controllers
{
    [Route("api/clinker")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        ClinkerRepository _repository = new ClinkerRepository();

        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            _repository.AddClinker(clinkerToAdd);

            return Created("", clinkerToAdd);  
        }

        [HttpGet("id/{Id}")]
        public IActionResult GetClinkerById(int id)
        {
            var result = _repository.GetClinkerById(id);
            return Ok(result);
        }

        [HttpGet("interest/{interestString}")]
        public IActionResult GetClinkersByInterest(string interestString)
        {
             var result = _repository.GetClinkersByInterest(interestString);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("There are no clinkers with this interest.");
        }

        [HttpGet("service/{serviceString}")]
        public IActionResult GetClinkersByServices(string serviceString)
        {
            var result = _repository.GetClinkersByServices(serviceString);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("There are no clinkers with the requested service.");
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetClinkers();

            return Ok(allClinkers);
        }

        [HttpPost("clinker/{clinkerId}/homie/{homieId}")]
        public IActionResult AddHomie(int clinkerId, int homieId)
        {
            var clinker = _repository.AddHomies(clinkerId, homieId);
            return Ok(clinker);
        }

        [HttpPost("clinker/{clinkerId}/enemy/{enemyId}")]
        public IActionResult AddEnemy(int clinkerId, int enemyId)
        {
            var clinker = _repository.AddEnemy(clinkerId, enemyId);
            return Ok(clinker);
        }

        [HttpPut("{AddOrRemove}/id/{clinkerId}/interest/{clinkerInterest}")]
        public IActionResult UpdateInterests(int clinkerId, string clinkerInterest, string AddOrRemove)
        {
            var clinker = _repository.UpdateInterests(clinkerId, clinkerInterest, AddOrRemove);
            return Ok(clinker);
        }

        [HttpPut("id/{clinkerId}/{clinkerService}")]
        public IActionResult UpdateService(int clinkerId, string clinkerService)
        {
            var clinker = _repository.UpdateService(clinkerId, clinkerService);
            return Ok(clinker);
        }
        
        [HttpGet("remainingDays/{clinkerId}")]
        public IActionResult RemainingDays(int clinkerId)
        {
            var days = _repository.RemainingSentence(clinkerId);
            return Ok($"There are {days} days remaining in the clinker's sentence.");
        }

        [HttpGet("crew/{clinkerId}")]
        public IActionResult GetClinkersCrew(int clinkerId)
        {
            var crew = _repository.GetClinkersCrew(clinkerId);
            var stringToPrint = "The clinker's crew: ";
            foreach (var mate in crew)
            {
                stringToPrint += mate.HoodName + ", ";
            }
            stringToPrint.Substring(stringToPrint.Length - 2);
            return Ok($"{stringToPrint}");
        }
    }
}