using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.AppointmentDtos;
using Entities.DataTransferObjects.ClinicalAssistantDtos;
using Entities.DataTransferObjects.DentistDtos;
using Entities.DataTransferObjects.EmployeeTypeDtos;
using Entities.DataTransferObjects.InvoiceDtos;
using Entities.DataTransferObjects.PatientDtos;
using Entities.DataTransferObjects.PaymentDtos;
using Entities.DataTransferObjects.PaymentMethodDtos;
using Entities.DataTransferObjects.TreatmentDetailsDtos;
using Entities.DataTransferObjects.TreatmentDtos;
using Entities.DataTransferObjects.TreatmentTypeDtos;

namespace WebApplication1.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppointmentDtoForInsertion, Appointment>();
            CreateMap<AppointmentDtoForUpdate, Appointment>();
            CreateMap<Appointment, AppointmentDtoForRead>();

            CreateMap<ClinicalAssistantDtoInsertion, ClinicalAssistant>();
            CreateMap<ClinicalAssistantDtoUpdate, ClinicalAssistant>();
            CreateMap<ClinicalAssistant, ClinicalAssistantDtoForRead>();

            CreateMap<DentistDtoForInsertion, Dentist>();
            CreateMap<DentistDtoForUpdate, Dentist>();
            CreateMap<Dentist, DentistDtoForRead>();

            CreateMap<EmployeeType, EmployeeTypeDtoForRead>();
            CreateMap<EmployeeTypeDtoForInsertion, EmployeeType>();
            CreateMap<EmployeeTypeDtoForUpdate, EmployeeType>();

            CreateMap<InvoiceDtoForInsertion, Invoice>();
            CreateMap<InvoiceDtoForUpdate, Invoice>();
            CreateMap<Invoice, InvoiceDtoForRead>();

            CreateMap<PatientDtoForInsertion, Patient>();
            CreateMap<PatientDtoForUpdate, Patient>();
            CreateMap<Patient, PatientDtoForRead>();

            CreateMap<PaymentDtoForInsertion, Payment>();
            CreateMap<PaymentDtoForUpdate, Payment>();
            CreateMap<Payment, PaymentDtoForRead>();

            CreateMap<PaymentMethodDtoForInsertion, PaymentMethod>();
            CreateMap<PaymentMethodDtoForUpdate, PaymentMethod>();
            CreateMap<PaymentMethod, PaymentMethodDtoForRead>();

            CreateMap<TreatmentDetailsDtoForInsertion, TreatmentDetail>();
            CreateMap<TreatmentDetailsDtoForUpdate, TreatmentDetail>();
            CreateMap<TreatmentDetail, TreatmentDetailDtoForRead>();

            CreateMap<TreatmentDtoForUpdate, Treatment>();
            CreateMap<TreatmentDtoForInsertion, Treatment>();
            CreateMap<Treatment, TreatmentDtoForRead>();

            CreateMap<TreatmentType, TreatmentTypeDtoForRead>();
            CreateMap<TreatmentTypeDtoForInsertion, TreatmentType>();
            CreateMap<TreatmentTypeDtoForUpdate, TreatmentType>();
        }
    }
}
