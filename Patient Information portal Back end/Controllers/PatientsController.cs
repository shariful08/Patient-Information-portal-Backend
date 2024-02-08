using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Information_portal_Back_end.Models;
using Patient_Information_portal_Back_end.Models.Dto;
using Patient_Information_portal_Back_end.Repository.IRepository;
using System.Net;

namespace Patient_Information_portal_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IPatientRepository _dbpatient;
        private readonly IMapper _mapper;
        public PatientsController(IPatientRepository dbpatient,IMapper mapper)
        {
            _dbpatient = dbpatient;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<APIResponse>>> GetAllPatients()
        {
            IEnumerable<PatientModel> patientList = await _dbpatient.GetAllAsync();
            _response.Result = _mapper.Map<List<PatientDTO>>(patientList);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("GetPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPatient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var patient = await _dbpatient.GetAsync(u => u.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<PatientDTO>(patient);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreatePatientDTO>> CreatePatientInfo([FromBody] CreatePatientDTO createPatient)
        {
            if (await _dbpatient.GetAsync(u => u.PatientName.ToLower() == createPatient.PatientName.ToLower()) != null)
            {
                return BadRequest(ModelState);
            }
            if (createPatient == null)
            {
                return BadRequest(createPatient);
            }
            PatientModel patient = _mapper.Map<PatientModel>(createPatient);

            await _dbpatient.CreateAsync(patient);

            _response.Result = _mapper.Map<PatientDTO>(patient);
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtRoute("GetPatient", new { id = patient.PatientId }, _response);
        }

        [HttpDelete("DeletePatientInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeletePatientInfo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var patient = await _dbpatient.GetAsync(u => u.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            await _dbpatient.RemoveAsync(patient);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePatientInfo(int id, [FromBody] UpdatePatientDTO updatePatient)
        {
            if (updatePatient == null || id != updatePatient.PatientId)
            {
                return BadRequest();
            }
            PatientModel patientModel = _mapper.Map<PatientModel>(updatePatient);

            await _dbpatient.UpdateAsync(patientModel);

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }


    }
}
