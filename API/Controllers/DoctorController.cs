using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTOS;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMedicationService _medicationService;
        private readonly ICaregiverService _caregiverService;

        public DoctorController(IPatientService patientService,
                                IMedicationService medService,
                                ICaregiverService caregiverService)
        {
            this._patientService = patientService;
            this._medicationService = medService;
            this._caregiverService = caregiverService;
        }

        [HttpGet("medications")]
        public ActionResult<List<MedicationDTO>> GetAllMedication()
        {
            List<MedicationDTO> medsDTO = new List<MedicationDTO>();

            var meds = _medicationService.GetAllMedications();

            meds.ForEach(m =>
            {
                MedicationDTO m1 = new MedicationDTO();
                m1.Id = m.Id;
                m1.Name = m.Name;
                m1.SideEffects = m.SideEffects;
                m1.Dosage = (decimal)m.Dosage;

                medsDTO.Add(m1);
            });

            return medsDTO;
            
        } 

        [HttpPost("medication")]
        public ActionResult CreateMedication(MedicationDTO medicationDTO)
        {
            Medication med = new Medication();
            med.Name = medicationDTO.Name;
            med.SideEffects = medicationDTO.SideEffects;
            med.Dosage = medicationDTO.Dosage;
            _medicationService.CreateMedication(med);
            return Ok();
        }

        [HttpPut("medication")]
        public ActionResult UpdateMedication(MedicationDTO medicationDTO)
        {
            Medication med = new Medication();
            med.Id = medicationDTO.Id;
            med.Name = medicationDTO.Name;
            med.SideEffects = medicationDTO.SideEffects;
            med.Dosage = medicationDTO.Dosage;
            _medicationService.UpdateMedication(med);
            return Ok();
        }

        [HttpDelete("medication/{id}")]
        public ActionResult DeleteMedication(int id)
        {
           
            _medicationService.DeleteMedication(id);
            return Ok();
        }

        [HttpGet("patients")]
        public ActionResult<List<PatientDTO>> GetAllPatients()
        {
            List<PatientDTO> patients = new List<PatientDTO>();

            var patients_data = _patientService.GetAllPatients();

            patients_data.ForEach(p =>
           {
               PatientDTO p1 = new PatientDTO();
               p1.id = (int)p.Id;
               p1.name = p.Name;
               p1.password = p.Password;
               p1.email = p.Email;
               p1.gender = p.Gender;
               p1.medicalRecord = p.UserPatient.ElementAt(0).MedicalRecord;
               p1.birthDate = (System.DateTime)p.BirthDate;
               p1.address = p.Address;

               patients.Add(p1);
           });

            return patients;

        }

        [HttpPost("patient")]
        public ActionResult<PatientDTO> CreatePatient(PatientDTO patient)
        {
           
            this._patientService.CreatePatient(patient);
            return Ok();
        }

        [HttpDelete("patient/{patientId}")]
        public ActionResult DeletePatient(int patientId)
        {
           
            this._patientService.DeletePatient(patientId);
            return Ok();
        }

        [HttpPut("patient")]
        public ActionResult UpdatePatient(PatientDTO patient)
        {

            this._patientService.UpdatePatient(patient);
            return Ok();
        }

        [HttpGet("caregivers")]
        public ActionResult<List<CaregiverDTO>> GetAllCaregivers()
        {
            //List<PatientDTO> patients = new List<PatientDTO>();

            var care_givers = _caregiverService.GetAllCaregivers();

            return Ok(care_givers);
          

           // return patients;

        }

        [HttpPost("caregiver")]
        public ActionResult AddCaregiver(CaregiverDTO caregiver)
        {
            

            _caregiverService.AddCaregiver(caregiver);

            return Ok();


           

        }


        [HttpPut("caregiver")]
        public ActionResult UpdateCaregiver(CaregiverDTO caregiver)
        {


            this._caregiverService.UpdateCaregiver(caregiver);

            return Ok();




        }


        [HttpDelete("caregiver/{id}")]
        public ActionResult DeleteCaregiver(int id)
        {


            _caregiverService.DeleteCaregiver(id);

            return Ok();




        }
    }
}
